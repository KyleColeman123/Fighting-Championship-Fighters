using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Character : MonoBehaviour
{
    public void StartCharacter()//Function referenced when the user decides to press a button that takes them to the character menu
    {
        SceneManager.LoadScene("Character");//Goes to the character scene
        Time.timeScale = 1;//Unfreezes gameplay time
        AudioListener.volume = 1;//Turns volume back up
    }
}
