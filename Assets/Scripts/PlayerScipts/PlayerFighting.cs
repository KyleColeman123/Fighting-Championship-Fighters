using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFighting : MonoBehaviour
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
        if (staminaSize.localScale.x < .1f) staminaBar.color = new Color32(255,0,0,255);//If the stamina is low, the bar becomes red
        else staminaBar.color = new Color32(0, 126, 255, 255);//Else, it is blue

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

        if (mid.enabled == false && low.enabled == false)//Checks to see if the character does not have the mid and low hitboxes active
        {
            if (Input.GetKeyDown("i") && staminaSize.localScale.x >= .25f) //Checks to see if the key "i" is pressed and if there is enough stamina
            {
                highStart();
            }
            if (Input.GetKeyUp("i"))//Checks to see if the key "i" is released 
            { 
                highEnd();
            }
        }

        if (high.enabled == false && low.enabled == false)//Checks to see if the character does not have the high and low hitboxes active
        {
            if (Input.GetKeyDown("o") && staminaSize.localScale.x >= .15f) //Checks to see if the key "o" is pressed and if there is enough stamina
            { 
                midStart();
            }
            if (Input.GetKeyUp("o"))//Checks to see if the key "o" is released 
            { 
                midEnd();
            }
        }

        if (high.enabled == false && mid.enabled == false)//Checks to see if the character does not have the high and mid hitboxes active
        {
            if (Input.GetKeyDown("p") && staminaSize.localScale.x >= .1f) //Checks to see if the key "p" is pressed and if there is enough stamina
            { 
                lowStart();
            }
            if (Input.GetKeyUp("p"))//Checks to see if the key "p" is released 
            {
                lowEnd();
            }
        }
        

    }

    void highStart()//Start the animation and execution of the high attack
    {
        animator.SetBool("hi", true);//Turns on high attack animation
        high.enabled = true;//Turns on high attack hit box
        PlayerPrefs.SetInt("HighAtt", PlayerPrefs.GetInt("HighAtt") + 1);//Tracks high attack attempts
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
        PlayerPrefs.SetInt("MidAtt", PlayerPrefs.GetInt("MidAtt") + 1);//Tracks mid attack attempts
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
        low.enabled = true;//Turns on low attack hit box
        PlayerPrefs.SetInt("LowAtt", PlayerPrefs.GetInt("LowAtt") + 1);//Tracks low attack attempts
        stamina -= .1f;//Takes certain amount of stamina
        staminaSize.localScale = new Vector3(stamina, 1, 1);//Show stamina decrease on screen
    }

    void lowEnd()//Ends the animation and execution of the low attack
    {
        animator.SetBool("low", false);//Turns off mid attack animation
        low.enabled = false;//Turns off mid attack hit box
    }

    public void increaseStamina(){//Increases the stamina (recovery)
        stamina += .006f;
        staminaSize.localScale = new Vector3(stamina, 1, 1);
    }
}
