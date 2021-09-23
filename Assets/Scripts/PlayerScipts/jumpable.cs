using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpable : MonoBehaviour
{
    public Animator animator;
    public bool canJump;
    public Rigidbody2D player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "blast")
        {
            canJump = true;
        }
        
    }

    public void Update()
    {
        if (canJump == true)
        {
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                jumpStart();
            }
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
        {
            jumpEnd();
        }
    }

    void jumpStart()
    {
        animator.SetBool("jump", true);
        player.AddForce(new Vector2(0, (float)25), ForceMode2D.Impulse);
        canJump = false;
    }
    void jumpEnd()
    {
        animator.SetBool("jump", false);
    }
}
