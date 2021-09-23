using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator animator;//calls the animation component from a character


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))//Detects if key "w" or up arrow key is pressed
        {
            animator.SetBool("jump", true);//turns animation on
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
        {
            animator.SetBool("jump", false);//turns animation off
        }

    }
}
