using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFighting : MonoBehaviour
{
    public Animator animator;//Calls the animation component from a character
    float elapsed = 0f;//Variable used for real time code execution
    float stamina = 1f;//Variable used to track the amount of stamina for the player
    //References the stamina bar image (for color) and stamina transform for horizontal size flunctuations
    public Image staminaBar;
    public Transform staminaSize;
    //References the high, mid, and low hitboxes from a character
    public BoxCollider2D high;
    public BoxCollider2D mid;
    public BoxCollider2D low;


    void Update()
    {
        float x = Random.Range(.05f, .2f);//Generates random numbers for variable execution based on time
        int i = Random.Range(0, 60);//Generates random numbers for strike activation
        elapsed += Time.deltaTime;//creates a variable based on time
        if (elapsed >= x)//For every random fraction of a second
        { 
            elapsed = elapsed % x;
            if (mid.enabled == false && low.enabled == false && staminaSize.localScale.x >= .25f && i>50)//If the mid and low strikes are disabled 
            {                                                                                            //and the random number i is greater than 50 
                highStart();
                Invoke("highEnd", .2f);//Invokes function after .2 seconds. Helps animations run smoothly
            }

            if (high.enabled == false && low.enabled == false && staminaSize.localScale.x >= .15f && i<30)//If the high and low strikes are disabled 
            {                                                                                             //and the random number i is less than 30
                midStart();
                Invoke("midEnd", .2f);
            }

            if (high.enabled == false && mid.enabled == false && staminaSize.localScale.x >= .1f && (i<50 && i>30))//If the high and mid strikes are disabled 
            {                                                                                                      //and the random number i is less than 30
                lowStart();
                Invoke("lowEnd", .2f);
            }
        }

        if (staminaSize.localScale.x < .1f) staminaBar.color = new Color32(255, 0, 0, 255);
        else staminaBar.color = new Color32(0, 126, 255, 255);

        if (staminaSize.localScale.x <= 1)//If the stamina is below full capacity, it increases it by a little periodically in fractions of seconds
        {
            elapsed += Time.deltaTime;
            if (elapsed >= .05f)
            {
                elapsed = elapsed % .05f;
                increaseStamina();
            }
        }
        if (staminaSize.localScale.x <= 0)//Keeps stamina from going negative
        {
            staminaSize.localScale = new Vector3(1, 1, 1);
            stamina = 0;
        }

        


    }

    void highStart()//Start the animation and execution of the high attack
    {
        animator.SetBool("hi", true);//Turns on high attack animation
        high.enabled = true;//Turns on high attack hit box
        stamina -= .25f;//Takes certain amount of stamina
        staminaSize.localScale = new Vector3(stamina, 1, 1);//Show stamina decrease on screen
    }

    void highEnd()//Ends the animation and execution of the high attack
    {
        animator.SetBool("hi", false);//Turns off high attack animation
        high.enabled = false;//Turns off high attack hit box
    }

    void midStart()//Start the animation and execution of the mid attack
    {
        animator.SetBool("mid", true);//Turns on mid attack animation
        mid.enabled = true;//Turns on mid attack hit box
        stamina -= .15f;//Takes certain amount of stamina
        staminaSize.localScale = new Vector3(stamina, 1, 1);//Show stamina decrease on screen
    }

    void midEnd()//Ends the animation and execution of the mid attack
    {
        animator.SetBool("mid", false);//Turns off mid attack animation
        mid.enabled = false;//Turns off mid attack hit box
    }

    void lowStart()//Start the animation and execution of the low attack
    {
        animator.SetBool("low", true);//Turns on low attack animation
        stamina -= .1f;//Takes certain amount of stamina
        staminaSize.localScale = new Vector3(stamina, 1, 1);//Show stamina decrease on screen
        low.enabled = true;//Turns on low attack hit box
    }

    void lowEnd()//Ends the animation and execution of the low attack
    {
        animator.SetBool("low", false);//Turns off mid attack animation
        low.enabled = false;//Turns off mid attack hit box
    }

    public void increaseStamina()//Increases the stamina (recovery)
    {
        stamina += .006f;
        staminaSize.localScale = new Vector3(stamina, 1, 1);
    }
}
