using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //References the camera, the player, and enemy objects
    public GameObject cam;
    public Rigidbody2D player1;
    public Rigidbody2D player2;

    // Update is called once per frame
    void Update()
    {
        //Stores the transform values of both characters
        float xpos1 = player1.position.x;
        float ypos1 = player1.position.y;
        float xpos2 = player2.position.x;
        float ypos2 = player2.position.y;
        //Moves camera between both character
        cam.transform.position = new Vector3((xpos1+xpos2*.75f)/2 + 2, player1.position.y * 0.2f + 6, -10);
    }
}
