using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public float jumpForce = 10f;
    public float downForce = 15f;
    private int jumpCount = 0;
    private bool isGrounded = false;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] TextMeshProUGUI yourScore;

    [SerializeField] EnemyController enemyController;



    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        RotationDirection();
    }

    public void JumpPlayer()
    {
        if (isGrounded || jumpCount < 2)
        {

            if (jumpCount == 1)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Double_Jump2", false);
            }

            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            jumpCount++;


            if (jumpCount == 2)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Double_Jump2", true);
            }

            else
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Double_Jump2", false);
            }


        }

    }

    public void DownPlayer()
    {
        if (isGrounded == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * downForce;

        }
    }


    private void RotationDirection()
    {
        if (rb.velocity.x > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f); // Saða dönüþ
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else if (rb.velocity.x < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f); // Sola dönüþ
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else
        {
            anim.SetFloat("Speed", 0f); // Durma animasyonuna geçiþ yap
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isGrounded = true;
            anim.SetBool("Jump", false);
            anim.SetBool("Double_Jump2", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("Jump", true);

        }
    }


    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        yourScore.text = "Your Score: " + enemyController.score;
        Debug.Log("GameOver");

    }
}
