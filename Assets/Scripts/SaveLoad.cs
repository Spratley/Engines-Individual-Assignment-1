using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
   
public struct SaveObj
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}

public class SaveLoad : MonoBehaviour
{
    const string DLL_NAME = "SaveLoad";

    [DllImport(DLL_NAME)]
    public static extern bool Save();

    [DllImport(DLL_NAME)]
    public static extern void PushToStack(SaveObj toSave);

    [DllImport(DLL_NAME)]
    public static extern int PreloadObjects();

    [DllImport(DLL_NAME)]
    public static extern SaveObj LoadObject(int id);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearCubes();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            ClearCubes();

            int numObjs = PreloadObjects();
            for(int i = 0; i < numObjs; ++i)
            {
                GameObject cubieboy = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubieboy.GetComponent<MeshRenderer>().material.color = Color.blue;
                cubieboy.AddComponent<BoxCollider>();
                cubieboy.tag = "Saveable";

                SaveObj data = LoadObject(i);

                cubieboy.transform.position = data.position;
                cubieboy.transform.rotation = Quaternion.Euler(data.rotation);
                cubieboy.transform.localScale = data.scale;

            }
        }


        if (Input.GetKeyDown(KeyCode.P))
        {

            //PushToSaveStack(transform.position, transform.rotation.eulerAngles, transform.localScale);
            GameObject[] objectsToSave = GameObject.FindGameObjectsWithTag("Saveable");
            foreach (GameObject go in objectsToSave)
            {
                SaveObj obj = new SaveObj();
                obj.position = go.transform.position;
                obj.rotation = go.transform.rotation.eulerAngles;
                obj.scale = go.transform.localScale;

                PushToStack(obj);
            }
            Save();
            //if (!)
            //    Debug.Log("ERROR: Failed to save");
            //else
            Debug.Log("Save successful!");
        }
    }

    void ClearCubes()
    {
        GameObject[] objectsToClear = GameObject.FindGameObjectsWithTag("Saveable");
        foreach (GameObject go in objectsToClear)
            Destroy(go);
    }
}
