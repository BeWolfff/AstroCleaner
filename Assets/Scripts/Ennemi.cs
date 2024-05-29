using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ennemi : MonoBehaviour
{
    public float speed;
    public int direction = 1;
    public GameObject player;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    void Update()
    {
        if (player.transform.position.x > GetComponent<Transform>().position.x)
        {
            direction = 1;
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + speed * Time.deltaTime * direction,
            GetComponent<Transform>().position.y,
            GetComponent<Transform>().position.z);
        }

        if (player.transform.position.x < GetComponent<Transform>().position.x)
        {
            direction = -1;
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + speed * Time.deltaTime * direction,
            GetComponent<Transform>().position.y,
            GetComponent<Transform>().position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            player.GetComponent<PlayerMov>().score += 40;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreText.text = "Score: " + player.GetComponent<PlayerMov>().score;
        }

        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<HealthBar>().vie -= 10;
            if (player.transform.position.x < GetComponent<Transform>().position.x)
            {
                player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x - 0.75f,
                                                             player.GetComponent<Transform>().position.y,
                                                             player.GetComponent<Transform>().position.z);
            }
            if (player.transform.position.x > GetComponent<Transform>().position.x)
            {
                player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x + 0.75f,
                                                             player.GetComponent<Transform>().position.y,
                                                             player.GetComponent<Transform>().position.z);
            }
        }

    }
}
