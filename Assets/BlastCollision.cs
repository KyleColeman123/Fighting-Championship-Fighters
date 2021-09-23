using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastCollision : MonoBehaviour
{
    public Rigidbody2D blast;
    public GameObject blastObj;
    public GameObject player;


    void Update()
    {
        if (Mathf.Abs(blast.transform.position.x - player.transform.position.x) > 30f)
        {
            destroyBlast();
            Debug.Log("destroyed by far");
        }     
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        destroyBlast();
    }
    void destroyBlast()
    {
        blast.transform.position = new Vector3(-5, -10f, 0);
        blast.velocity = new Vector2(0, 0);
    }
}
