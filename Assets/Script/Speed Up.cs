using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player_rb;

    private bool applyForce = false;
    public float thrust = 5f;
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player")) {
            player_rb = player.GetComponent<Rigidbody2D>() as Rigidbody2D;
            if (player_rb.velocity.y <= 3 && player_rb.velocity.y >= 0) {
                applyForce = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (applyForce)
        {
            player_rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            applyForce = false;
        }
    }


}
