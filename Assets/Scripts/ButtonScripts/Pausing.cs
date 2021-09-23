using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour
{
    public bool isPause;
    //References the pause screen and button
    public GameObject pauseCanvas;
    public GameObject pauseButton;
    //Refences text objects on the screen
    public Text pA;
    public Text pD;
    public Text eA;
    public Text eD;
    

    void Start()
    {
        //PLaces the player and enemy stats on the screen
        pA.text = "Player Attack: " + PlayerPrefs.GetInt("PlayerAttack").ToString();
        pD.text = "Player Defense: " + PlayerPrefs.GetInt("PlayerDefense").ToString();
        eA.text = "Enemy Attack: " + PlayerPrefs.GetInt("EnemyAttack").ToString();
        eD.text = "Enemy Defense: " + PlayerPrefs.GetInt("EnemyDefense").ToString();
        Time.timeScale = 1;//Defaults the gameplay time to 1 (regular time)
    }
    void Update()
    {
        
        if (Input.GetKeyDown("space") && isPause == false) //Detects if the user presses the the spacebar and if the game is not paused
        {
            PAUSE();
        }
        else if (Input.GetKeyDown("space") && isPause == true) //Detects if the user presses the the spacebar and if the game is paused
        {
            UNPAUSE();
        }
    }

    public void PAUSE()//Function referenced when the user decides to press a button that pauses the game
    {
        isPause = true;
        Time.timeScale = 0;//Freezes gameplay time
        AudioListener.volume = 0;//Mutes volume
        pauseCanvas.gameObject.SetActive(!pauseCanvas.gameObject.activeSelf);//Enables pause screen
        pauseButton.gameObject.SetActive(!pauseButton.gameObject.activeSelf);//Disable pause button
        Debug.Log(isPause.ToString());
    }

    public void UNPAUSE()//Function referenced when the user decides to press a button that unpauses the game
    {
        isPause = false;
        Time.timeScale = 1;//Unfreezes gameplay time
        AudioListener.volume = 1;//Turns volume back up
        pauseCanvas.gameObject.SetActive(!pauseCanvas.gameObject.activeSelf);//Disables pause screen
        pauseButton.gameObject.SetActive(!pauseButton.gameObject.activeSelf);//Enables pause button
    }
}
