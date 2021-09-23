using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighStats : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")//If there is a collision with the enemy
        {
            PlayerPrefs.SetInt("HighSucc", PlayerPrefs.GetInt("HighSucc") + 1);//Tracks high attack successful hits
        }
    }
}
