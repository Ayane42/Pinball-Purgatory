using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private Transform ballTransform;
    private Rigidbody rb;
    private int score;
    private int scoreMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void BiggerBall()
    {
        ballTransform.localScale = new Vector2(ballTransform.localScale.x + 1f, ballTransform.localScale.y + 1f);
    }

    void HeavierBall()
    {
        rb.AddForce(Physics.gravity * 2, ForceMode.Acceleration);
    }

    void TreasureBall()
    {
        scoreMultiplier += 1;
    }

    void GreedPotion()
    {
        int randNum = Random.Range(1, 4);
        if (randNum == 1)
        {
            score *= 4;
        }
        else
        {
            score /= 4;
        }
    }
}
