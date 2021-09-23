using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsScreen : MonoBehaviour
{
    //Refernces all texts object on the screen
    public Text Hattempts;
    public Text Hsuccess;
    public Text Mattempts;
    public Text Msuccess;
    public Text Lattempts;
    public Text Lsuccess;
    public Text succPerc;

    void Update()
    {
        //Makes all the text references on the screen and makes them into their respective stat numbers
        Hattempts.text = PlayerPrefs.GetInt("HighAtt").ToString();
        Hsuccess.text = PlayerPrefs.GetInt("HighSucc").ToString();
        Mattempts.text = PlayerPrefs.GetInt("MidAtt").ToString();
        Msuccess.text = PlayerPrefs.GetInt("MidSucc").ToString();
        Lattempts.text = PlayerPrefs.GetInt("LowAtt").ToString();
        Lsuccess.text = PlayerPrefs.GetInt("LowSucc").ToString();
        //Calculates the amount of successful hits
        float perc = (PlayerPrefs.GetInt("HighSucc") + PlayerPrefs.GetInt("MidSucc") + PlayerPrefs.GetInt("LowSucc"))/
            ((float)PlayerPrefs.GetInt("HighAtt") + PlayerPrefs.GetInt("MidAtt") + PlayerPrefs.GetInt("LowAtt"));
        succPerc.text = (perc*100.00f).ToString() + "%";
    }
}
