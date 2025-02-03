using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalB : MonoBehaviour
{
    public Transform destination;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
            Rigidbody2D other_rb = other.GetComponent<Rigidbody2D>() as Rigidbody2D;
            other_rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
