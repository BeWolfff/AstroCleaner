using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speed;
    public int jumpForce;
    public int canJump;
    public int score;
    public int vie;

    private Animator animator;
    private float previousY;
    private float checkInterval = 0.001f; // Intervalle de vérification de 1 milliseconde
    private float timeSinceLastCheck = 0f;

    private Rigidbody2D rb; // Référence au Rigidbody du joueur

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("Degaine", true);
        animator.SetBool("Shoot", false);
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", false);

        // Initialisation de la valeur précédente de Y
        previousY = transform.position.y;
        rb = GetComponent<Rigidbody2D>(); // Récupère le Rigidbody attaché au joueur
    }

    void Update()
    {
        timeSinceLastCheck += Time.deltaTime;

        if (timeSinceLastCheck >= checkInterval)
        {
            CheckVerticalMovement();
            timeSinceLastCheck = 0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8.60f)
        {
            MoveLeft();
        }
        else
        {
            ResetAnimation();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump < 1)
        {
            Jump();
        }
    }

    private void CheckVerticalMovement()
    {
        if (rb.velocity.y > 0.1f)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Fall", false);
        }
        else if (rb.velocity.y < -0.1f)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }

        previousY = transform.position.y;
    }

    private void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                                         transform.position.y,
                                         transform.position.z);
        if (speed < 5)
        {
            speed += 0.5f;
        }

        GetComponent<SpriteRenderer>().flipX = false;
        animator.SetBool("Walk", true);
        animator.SetBool("Degaine", false);
        animator.SetBool("Shoot", false);
    }

    private void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                                         transform.position.y,
                                         transform.position.z);
        if (speed < 5)
        {
            speed += 0.5f;
        }

        GetComponent<SpriteRenderer>().flipX = true;
        animator.SetBool("Walk", true);
        animator.SetBool("Degaine", false);
        animator.SetBool("Shoot", false);
    }

    private void ResetAnimation()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Degaine", true);
        animator.SetBool("Shoot", false);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        canJump++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = 0;
            ResetAnimation();
        }
    }
}
