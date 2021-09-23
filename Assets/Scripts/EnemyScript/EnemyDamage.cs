using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject win;//Refences the win text
    int healthFactor;//References a variable for attack and defense scaling in real time
    public Transform healthSize;//References the size of the health bar
    float hp = .5f;//References the amount of health points

    void Start()
    {
        healthSize.localScale = new Vector3(hp, .1f, 1);//Sets default health on screen
        if (PlayerPrefs.GetInt("EnemyDefense") < PlayerPrefs.GetInt("PlayerAttack"))//If the player's attack is less than the enemy's defense
            healthFactor = (PlayerPrefs.GetInt("PlayerAttack") - PlayerPrefs.GetInt("EnemyDefense")) + 10;//Set health factor equation
        else healthFactor = 10;
    }
    void Update()
    {
        if (healthSize.localScale.x < 0)//If the enemy loses all health
        {
            win.SetActive(true);//Enables win text
            Destroy(this.gameObject);//Destroys enemy
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") + 1);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "High")//If the enemy gets in contact with the player's high hitbox
        {
            if (hp > 0)//If the enemy has health
                hp -= .0025f * healthFactor;//Decrease health with respect to the health factor
            healthSize.localScale = new Vector3(hp, .1f, 1);//Shows health change on screen
        }
        if (collision.gameObject.name == "Mid")//If the enemy gets in contact with the player's mid hitbox
        {
            if (hp > 0)//If the enemy has health
                hp -= .0015f * healthFactor;//Decrease health with respect to the health factor
            healthSize.localScale = new Vector3(hp, .1f, 1);//Shows health change on screen
        }
        if (collision.gameObject.name == "Low")//If the enemy gets in contact with the player's low hitbox
        {
            if (hp > 0)//If the enemy has health
                hp -= .001f * healthFactor;//Decrease health with respect to the health factor
            healthSize.localScale = new Vector3(hp, .1f, 1);//Shows health change on screen
        }
    }

}
