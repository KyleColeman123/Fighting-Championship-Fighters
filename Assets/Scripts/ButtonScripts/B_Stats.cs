using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Stats : MonoBehaviour
{
    public void StartStats()//Function referenced when the user decides to press a button that takes them to the stats menu
    {
        SceneManager.LoadScene("Stats");//Goes to the stats scene
        Time.timeScale = 1;//Unfreezes gameplay time
        AudioListener.volume = 1;//Turns volume back up
    }
}
