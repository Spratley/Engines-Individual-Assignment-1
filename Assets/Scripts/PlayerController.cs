using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public float lookSpeed;
    public float reticleSpeed;

    private Vector3 cameraEulers;

    private GameObject reticle;
    private float reticleDist;

    private Vector3 p1;
    private Vector3 p2;

    public GameObject ghostCube;

    private void Start()
    {
        reticle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        reticle.GetComponent<MeshRenderer>().material.color = Color.red;
        reticle.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        reticle.AddComponent<SphereCollider>();
        reticle.layer = 2;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                if(hit.transform.tag == "Saveable")
                    Destroy(hit.collider.gameObject);
        }

        UpdatePlayerMovement();

        UpdateReticle();

        SpawnCube();
    }

    void UpdatePlayerMovement()
    {
        float moveSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = runSpeed;

        transform.position += Quaternion.AngleAxis(cameraEulers.y, Vector3.up) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;

        cameraEulers += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * lookSpeed;
        Camera.main.transform.rotation = Quaternion.Euler(cameraEulers);
    }

    void UpdateReticle()
    {
        reticleDist += Input.mouseScrollDelta.y * reticleSpeed;
        if (reticleDist < 1)
            reticleDist = 1;

        reticle.transform.position = Camera.main.transform.position + Camera.main.transform.forward * reticleDist;
    }

    void SpawnCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            p1 = reticle.transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            p2 = reticle.transform.position;

            Vector3 center = (p1 + p2) / 2;
            ghostCube.transform.position = center;

            if (Input.GetKey(KeyCode.E))
            {
                Vector3 a = Vector3.one * Mathf.Sqrt((p1 - p2).magnitude / 3);
                Vector3 b = p2 - center;
                float angle = Mathf.Acos(Vector3.Dot(a/2, b) / ((a/2).magnitude * b.magnitude));
                Vector3 axis = Vector3.Cross(a/2, b);
                ghostCube.transform.localScale = a;
                ghostCube.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, axis);
            }
            else
            {
                ghostCube.transform.rotation = Quaternion.identity;
                Vector3 scale;
                scale.x = Mathf.Abs(p1.x - p2.x);
                scale.y = Mathf.Abs(p1.y - p2.y);
                scale.z = Mathf.Abs(p1.z - p2.z);
                ghostCube.transform.localScale = scale;
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            GameObject cubieboy = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubieboy.GetComponent<MeshRenderer>().material.color = Color.blue;
            cubieboy.AddComponent<BoxCollider>();
            cubieboy.tag = "Saveable";
            cubieboy.transform.position = ghostCube.transform.position;
            cubieboy.transform.rotation = ghostCube.transform.rotation;
            cubieboy.transform.localScale = ghostCube.transform.localScale;
            ghostCube.transform.position = Vector3.down * 100000;
            
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    GameObject cubieboy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    cubieboy.GetComponent<MeshRenderer>().material.color = Color.blue;
        //    cubieboy.AddComponent<BoxCollider>();
        //    cubieboy.transform.position = reticle.transform.position;
        //    cubieboy.tag = "Saveable";
        //}
    }
}
