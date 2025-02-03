using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isKeyPressed = false;
    private  Rigidbody2D rb;
    public float speed = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isKeyPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            isKeyPressed = false;
        }
    }

    void FixedUpdate()
    {
        if (isKeyPressed) {
            rb.AddForce(transform.up * speed);
        }
    }
}
