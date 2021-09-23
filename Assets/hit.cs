using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public Rigidbody2D box;
        

    void Update()
    {
        box.AddForce(new Vector2(-15, 0));
    }
}
