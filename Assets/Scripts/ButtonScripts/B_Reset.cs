using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Reset : MonoBehaviour
{
    public void RESET()//Function referenced when the user decides to press a button that resets the tracked player stats
    {
        //Resets all stats
        PlayerPrefs.DeleteKey("HighAtt");
        PlayerPrefs.DeleteKey("MidAtt");
        PlayerPrefs.DeleteKey("LowAtt");
        PlayerPrefs.DeleteKey("HighSucc");
        PlayerPrefs.DeleteKey("MidSucc");
        PlayerPrefs.DeleteKey("LowSucc");

    }
}
