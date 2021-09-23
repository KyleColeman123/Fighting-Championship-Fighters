using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_QUIT : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            QUIT();
            
        }
    }
    

    public void QUIT()//Function referenced when the user decides to press a button that takes them to the stats menu
    {
        Debug.Log("QUITTINg");
        Application.Quit();
    }
}
