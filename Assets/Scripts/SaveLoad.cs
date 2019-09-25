using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
   
public class SaveLoad : MonoBehaviour
{
    const string DLL_NAME = "SaveLoad";

    [DllImport(DLL_NAME)]

    public static extern int Save(Transform input);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            Debug.Log(Save(transform));
            //GameObject[] objectsToSave = GameObject.FindGameObjectsWithTag("Saveable");
            //foreach (GameObject go in objectsToSave)
            //    if (!Save())
            //        Debug.Log("Failed to save " + go.name);
        }
    }
}
