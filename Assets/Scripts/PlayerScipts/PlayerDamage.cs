using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public GameObject lose;//Refences the lose text
    public Animator animator;//References the player's animations
    int healthFactor;//References a variable for attack and defense scaling in real time
    public Transform healthSize;//References the size of the health bar
    float hp = .5f;//References the amount of health points

    // Start is called before the first frame update
    void Start()
    {
        healthSize.localScale = new Vector3(hp, .1f, 1);//Sets default health on screen
        if (PlayerPrefs.GetInt("PlayerDefense") < PlayerPrefs.GetInt("EnemyAttack"))//If the enemy's attack is less than the player's defense
            healthFactor = (PlayerPrefs.GetInt("EnemyAttack") - PlayerPrefs.GetInt("PlayerDefense")) + 10;// Set health factor equation
        else healthFactor = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("["))//Detects if the user presses dow the "[" key
        {
            blockStart();
        }
        if (Input.GetKeyUp("["))//Detects if the user releases the "[" key
        {
            blockEnd();
        }

        if (healthSize.localScale.x < 0) //If the player loses all health
        {
            lose.SetActive(true);//Enables lose text
            Destroy(this.gameObject);//Destroys player

        }
    }

    void blockStart()
    {
        animator.SetBool("block", true);//Starts block animation
    }
    void blockEnd()
    {
        animator.SetBool("block", false);//Ends block animation
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!animator.GetBool("block"))//If the player is not blocking
        {
            if (collision.gameObject.name == "EHigh")//If the enemy gets in contact with the enemy's high hitbox
            {
                if (hp > 0)//If the player has health
                    hp -= .0025f * healthFactor;//Decrease health with respect to the health factor
                healthSize.localScale = new Vector3(hp, .1f, 1);//Shows health change on screen
            }
            if (collision.gameObject.name == "EMid")//If the enemy gets in contact with the enemy's mid hitbox
            {
                if (hp > 0)//If the player has health
                    hp -= .0015f * healthFactor;//Decrease health with respect to the health factor
                healthSize.localScale = new Vector3(hp, .1f, 1);//Shows health change on screen
            }
            if (collision.gameObject.name == "ELow")//If the enemy gets in contact with the enemy's low hitbox
            {
                if (hp > 0)//If the player has health
                    hp -= .001f * healthFactor;//Decrease health with respect to the health factor
                healthSize.localScale = new Vector3(hp, .1f, 1);//Shows health change on screen
            }
        }
        
    }
    }
