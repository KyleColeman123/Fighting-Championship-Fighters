using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Title : MonoBehaviour
{
    public void StartTitle()//Function referenced when the user decides to press a button that takes them to the title menu
    {
        SceneManager.LoadScene("Title");//Goes to the title scene
        Time.timeScale = 1;//Unfreezes gameplay time
        AudioListener.volume = 1;//Turns volume back up
    }
}
