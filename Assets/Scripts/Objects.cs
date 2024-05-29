
using UnityEngine;
using TMPro;

public class Objects : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            player.GetComponent<PlayerMov>().score += 15;
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
