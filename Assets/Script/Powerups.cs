using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Powerups : MonoBehaviour
{
    private Transform ballTransform;
    private Rigidbody2D rb;
    public int score;
    public int treasure;
    public int lives = 5;
    public float speedx = 5;
    public Transform respawnLoc;
    private int scoreMultiplier;
    public float gravityMultiplier = 1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI treasureText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI endScoreText;
    public GameObject endGame;
    public GameObject shopUI;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        treasure = 0;
        scoreMultiplier = 1;
        rb.AddForce(transform.up * speedx);
    }

    void Update()
    {
        if (ballOutOfGame()) {
            ballTransform.transform.position = new Vector2(respawnLoc.position.x, respawnLoc.position.y + 1.0f);
            rb.velocity = new Vector2(0.0f, 0.0f);
            Debug.Log("Ball out of bounds");
        }
    }

    bool ballOutOfGame() {
        return (ballTransform.position.x < -5 || ballTransform.position.x > 5 || ballTransform.position.y > 8.5 );
    }

    // Update is called once per frame
    public void SmallerBall()
    {
        if (treasure >= 1000)
        {
            treasure -= 1000;
            ballTransform.localScale = new Vector2(ballTransform.localScale.x - 0.05f, ballTransform.localScale.y - 0.05f);
            treasureText.text = treasure.ToString();
        }
    }

    public void LighterBall()
    {
        if (treasure >= 750)
        {
            treasure -= 750;
            gravityMultiplier += 1;
            treasureText.text = treasure.ToString();
        }
    }

    public void TreasureBall()
    {
        if (treasure >= 1500)
        {
            treasure -= 1500;
            scoreMultiplier += 1;
            treasureText.text = treasure.ToString();
        }
    }

    public void GreedPotion()
    {
        if (treasure >= 500)
        {
            treasure -= 500;
            int randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                treasure *= 4;
                treasureText.text = treasure.ToString();
            }
            else
            {
                treasure /= 2;
                treasureText.text = treasure.ToString();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Richochets")){
            updateScore();
            updateTreasure();
            
        }
    }


    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            if (lives > 0)
            {
                ballTransform.transform.position = new Vector2(respawnLoc.position.x, respawnLoc.position.y + 1.0f);
                rb.velocity = new Vector2(0.0f, 0.0f);
                lives = lives - 1;
                livesText.text = lives.ToString();
            }
            else if (lives == 0)
            {
                endGame.SetActive(true);
                shopUI.SetActive(false);
                Time.timeScale = 0f;
                endScoreText.text = score.ToString();
            }
        }
        if (collision.gameObject.CompareTag("Richochets") && rb.velocity.y >= 0)
        {
            updateScore();
            updateTreasure();

        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityMultiplier - 1), ForceMode2D.Force);
    }

    void updateScore(){
        score+=250;
        scoreText.text = score.ToString();
    }

    void updateTreasure(){
        treasure+=250;
        treasureText.text = treasure.ToString();
    }
}
