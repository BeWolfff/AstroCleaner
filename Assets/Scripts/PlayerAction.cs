using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("Degaine", true);
        animator.SetBool("Shoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<SpriteRenderer>().flipX == false )
        {
            bullet.GetComponent<Bullet>().direction = 1;
            GameObject ballGO = Instantiate(bullet);
            ballGO.transform.position = new Vector3(player.GetComponent<Transform>().position.x + 1, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
            animator.SetBool("Walk", false);
            animator.SetBool("Degaine", false);
            animator.SetBool("Shoot", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<SpriteRenderer>().flipX == true  )
        {
            bullet.GetComponent<Bullet>().direction = -1;
            GameObject ballGO = Instantiate(bullet);
            ballGO.transform.position = new Vector3(player.GetComponent<Transform>().position.x - 1, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
            animator.SetBool("Walk", false);
            animator.SetBool("Degaine", false);
            animator.SetBool("Shoot", true);
        }
    }
}
