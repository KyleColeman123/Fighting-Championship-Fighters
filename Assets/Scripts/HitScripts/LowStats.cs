using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowStats : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")//If there is a collision with the enemy
        {
            PlayerPrefs.SetInt("LowSucc", PlayerPrefs.GetInt("LowSucc") + 1);//Tracks low attack successful hits
        }
    }
}
