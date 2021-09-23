using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{

    public Rigidbody2D blast;
    public GameObject blastObj;
    public Rigidbody2D player;
    public GameObject playerS; //for scaling
    public Transform energySize;
    public float energy = 1.5f;


    void Update()
    {

        //Debug.Log("DIFFERENCE " + Mathf.Abs(blast.transform.position.x - player.transform.position.x));

        if (Input.GetKeyDown("space") && blast.transform.position == new Vector3(-5, -10f, 0) && energy >= .05)
        {
            if (playerS.transform.localScale.x == -1f) //backward blast movement
            {
                blast.position = new Vector2(player.position.x - 2f, player.position.y);
                blast.velocity = new Vector2(-20f, 0);
            }
            else if (playerS.transform.localScale.x == 1f) //forward blast movement
            {
                blast.position = new Vector2(player.position.x + 2f, player.position.y);
                blast.velocity = new Vector2(20f, 0);
            }

            energy -= .05f;
            energySize.localScale = new Vector3(energy, .1f, 1);

            /*if (Mathf.Abs(blast.transform.position.x - player.transform.position.x) > 36f)
                //destroyBlast();
                Debug.Log("destroyed by far");
                */
        }
        
    }

    
}
