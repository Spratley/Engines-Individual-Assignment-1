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

    private void Start()
    {
        reticle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        reticle.GetComponent<MeshRenderer>().material.color = Color.red;
        reticle.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdatePlayerMovement();

        UpdateReticle();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cubieboy = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubieboy.GetComponent<MeshRenderer>().material.color = Color.blue;
            cubieboy.transform.position = reticle.transform.position;
            cubieboy.tag = "Saveable";
        }
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
}
