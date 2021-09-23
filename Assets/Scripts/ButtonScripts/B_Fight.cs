using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Fight : MonoBehaviour
{
    public void StartFightEasy()//Function referenced when the user decides to press a button that takes them to the fight on easy difficulty
    {
        Time.timeScale = 1;//Unfreezes gameplay time
        AudioListener.volume = 1;//Turns volume back up
        //Gets players stats
        int a = PlayerPrefs.GetInt("PlayerAttack");
        int d = PlayerPrefs.GetInt("PlayerDefense");
        //Generates random stats for the enemy character, similar to the players stats
        int i = Random.Range(a/2, a + a/2);
        int j = Random.Range(d/2, d + d/2);
        //Sets stats for the enemy character, similar to the players stats
        PlayerPrefs.SetInt("EnemyAttack", i);
        PlayerPrefs.SetInt("EnemyDefense", j);
        SceneManager.LoadScene("Fight");//Loads fight scene
    }
    public void StartFightHard()//Function referenced when the user decides tot press a button that takes them to the fight on hard difficulty
    {
        Time.timeScale = 1;//Unfreezes gameplay time
        AudioListener.volume = 1;//Turns volume back up
        //Gets players stats
        int a = PlayerPrefs.GetInt("PlayerAttack");
        int d = PlayerPrefs.GetInt("PlayerDefense");
        //Generates random stats for the enemy character, similar to the players stats
        int i = Random.Range(a / 2, a + a / 2);
        int j = Random.Range(d / 2, d + d / 2);
        //Sets stats for the enemy character, usually quite higher than the players stats
        PlayerPrefs.SetInt("EnemyAttack", i*2);
        PlayerPrefs.SetInt("EnemyDefense", j*2);
        SceneManager.LoadScene("Fight");//Loads fight scene
    }
}
