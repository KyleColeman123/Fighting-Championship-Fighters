using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Refences the enemy's physical components
    public Rigidbody2D enemy;
    public GameObject enemyS;
    //Refences the player's physical components
    public Rigidbody2D player;
    public Animator animator;//Calls the animation component from a character


    void Update()
    {
        float enemyPos = enemy.transform.position.x;//References the enemy's position
        float playerPos = player.transform.position.x;//References the player's position

        if (playerPos - enemyPos < -2) //if the player is behind the enemy
        {
            leftStart();
        }
        else if (playerPos - enemyPos > 2) //if the player is in front of the enemy
        {
            rightStart();
        }
        

        if (enemyPos - playerPos > 0) enemyS.transform.localScale = new Vector3(-1f, 1f, 1f);//Orients character in the left direction
        else if (enemyPos - playerPos < 0) enemyS.transform.localScale = new Vector3(1f, 1f, 1f);//Orients character in the right direction

        if (enemy.velocity.x > -0.5f && enemy.velocity.x < 0.5f) animator.SetBool("walk", false);

    }

    void leftStart()//Start the animation and execution of moving left
    {
        enemy.velocity = new Vector3(-10, enemy.velocity.y);//Moves character left at a certain velocity
        animator.SetBool("walk", true);//Turns on walk animation
    }
    void leftEnd()//Ends the animation and execution of moving left
    {
        enemy.velocity = new Vector3(0, enemy.velocity.y);//Stops character
        animator.SetBool("walk", false);//Turns off walk animation
    }
    void rightStart()//Start the animation and execution of moving right
    {
        enemy.velocity = new Vector3(10, enemy.velocity.y);//Moves character right at a certain velocity
        animator.SetBool("walk", true);//Turns on walk animation
    }
    void rightEnd()//Ends the animation and execution of moving right
    {
        enemy.velocity = new Vector3(0, enemy.velocity.y);//Stops character
        animator.SetBool("walk", false);//Turns off walk animation
    }
}
