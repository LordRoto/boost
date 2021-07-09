using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
   
   
    void Update()
    {
        ProcessQuit();
    }

    void ProcessQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Debug.Log("You Quit");Application.Quit();
        }

    }



}
