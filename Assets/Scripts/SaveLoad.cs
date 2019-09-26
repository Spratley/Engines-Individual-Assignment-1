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
    public static extern void PushToSaveStack(SaveObj toSave);

    [DllImport(DLL_NAME)]
    public static extern int GetNumberOfLines();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(GetNumberOfLines());
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

                PushToSaveStack(obj);
            }
            if (!Save())
                Debug.Log("ERROR: Failed to save");
            else
                Debug.Log("Save successful!");
        }
    }
}
