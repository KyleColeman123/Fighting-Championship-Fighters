using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidStats : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")//If there is a collision with the enemy
        {
            PlayerPrefs.SetInt("MidSucc", PlayerPrefs.GetInt("MidSucc") + 1);//Tracks mid attack successful hits
        }
    }
}
