using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;//Calls the animation component from a character
    //Refences the player's physical components
    public Rigidbody2D player;
    public GameObject playerS;
    //References the high, mid, and low hitboxes from a character
    public BoxCollider2D high;
    public BoxCollider2D mid;
    public BoxCollider2D low;


    void Update()
    {
        if (player.transform.position.y < -10) //Prevents under map glitches
        {
            player.transform.position = new Vector3 (player.position.x, 5);//Teleports character 5 units above
        }

        if ((Input.GetKey("right") || Input.GetKey("d")) && !animator.GetBool("block")//Checks to see if the right arrow key or "d" was pressed, if the player is not blocking
            && high.enabled == false && mid.enabled == false && low.enabled == false)//and if the player is not attacking
        {
            rightStart();
        }
        if (Input.GetKeyUp("right") || Input.GetKeyUp("d")){//Checks to see if the right arrow key or "d" was released
            rightEnd();
        }

        if ((Input.GetKey("left") || Input.GetKey("a")) && !animator.GetBool("block")//Checks to see if the left arrow key or "a" was pressed, if the player is not blocking
            && high.enabled == false && mid.enabled == false && low.enabled == false)//and if the player is not attacking
        {
            leftStart();
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("a"))//Checks to see if the left arrow key or "a" was released
        {
            leftEnd();
        }
    }

    void leftStart()//Start the animation and execution of moving left
    {
        player.velocity = new Vector3(-15, player.velocity.y);//Moves character left at a certain velocity
        playerS.transform.localScale = new Vector3(-1f, 1f, 1f);//Orients character in the left direction
        animator.SetBool("walk", true);//Turns on walk animation
    }
    void leftEnd()//Ends the animation and execution of moving left
    {
        animator.SetBool("walk", false);//Turns off walk animation
    }
    void rightStart()//Start the animation and execution of moving right
    {
        player.velocity = new Vector3(15, player.velocity.y);//Moves character right at a certain velocity
        playerS.transform.localScale = new Vector3(1f, 1f, 1f);//Orients character in the right direction
        animator.SetBool("walk", true);//Turns on walk animation
    }
    void rightEnd()//Start the animation and execution of moving right
    {
        animator.SetBool("walk", false);//Turns off walk animation
    }
}
