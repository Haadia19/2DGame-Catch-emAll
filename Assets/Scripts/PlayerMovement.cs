using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMovement = 0f;
    float playerSpeed = 6f;
    bool inAir = false;

    SpriteRenderer spriteRenderer;
    Rigidbody2D Rigidbody2D;
    Animator animator;
    AudioManager audioManager;

    public GameObject confetti;
    public HealthController healthBar;
    float health = 5f;

    Vector3 forward, backward;
    Vector3 playerPosition;

    private bool moveLeft, moveRight, jump;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
        forward = new Vector3(0, 0, 0);
        backward = new Vector3(0, 180, 0);
        audioManager.playMySound("BackGround");
        playerPosition = transform.position;
        healthBar.setHealth(ScoreManager.GetInstance().getHealth());

        moveLeft = false;
        moveRight = false;
        jump = false;
    }
    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }

    public void isJump()
    {
        jump = true;
    }
    public void stopMovement()
    {
        moveLeft = false;
        moveRight = false;
        horizontalMovement = 0;
    }
    void Update()
    {

        ScoreManager.GetInstance().displayHighScore();

        healthBar.setHealth(ScoreManager.GetInstance().getHealth());

        if (moveLeft)
        {
            horizontalMovement = (-playerSpeed) * Time.deltaTime;
        }
        else if (moveRight)
        {
            horizontalMovement = (playerSpeed) * Time.deltaTime;
        }
        transform.position += new Vector3(horizontalMovement, 0, 0);
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

        if (jump)
        {
            if (!inAir)
            {
                Rigidbody2D.AddForce(Vector3.up * 600);
                animator.SetBool("isJumping", true);
                inAir = true;
            }
            else
            {
                jump = false;
            }
        }
        // for rotating player and basket

        if (horizontalMovement > 0)
        {
            transform.eulerAngles = forward;
        }
        else if (horizontalMovement < 0)
        {
            transform.eulerAngles = backward;
        }

        if (ScoreManager.GetInstance().getScore() < 0 || ScoreManager.GetInstance().getLifeline() == 0 || ScoreManager.GetInstance().getHealth() <= 0)
        {
            audioManager.playMySound("GameOver");
            LevelManager.instance.hideAllLevels();
            LevelManager.instance.displayGameOverMenu();
        }

        /*        if(ScoreManager.GetInstance().getScore() == 10)
                {
                    audioManager.playMySound("LevelComplete");
                    LevelManager.instance.displayLevelComplete();
                }*/
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Crate") || collision.gameObject.CompareTag("Box"))
        {
            animator.SetBool("isJumping", false);
            inAir = false;
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            animator.SetBool("isDead", true);
            audioManager.playMySound("GameOver");
            StartCoroutine(playerAlive());
        }

        if (collision.gameObject.CompareTag("Cactus") || collision.gameObject.CompareTag("Monster"))
        {
            Rigidbody2D.AddForce(Vector3.up * 200);
            audioManager.playMySound("Hurt");
            ScoreManager.GetInstance().reduceHealth();
            audioManager.playMySound("Ouch");
            healthBar.setHealth(ScoreManager.GetInstance().getHealth());
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            GameObject ob = Instantiate(confetti);
            Destroy(ob, 2.5f);

            for (int i = 0; i < 10; i++)
            {
                ScoreManager.GetInstance().addScore();
            }
            audioManager.playMySound("bonus");
        }
    }

    IEnumerator playerAlive()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("isDead", false);
        ScoreManager.GetInstance().resestScore();
        transform.position = playerPosition;
    }
}
