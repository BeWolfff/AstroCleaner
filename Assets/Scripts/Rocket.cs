using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fusee : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GetComponent<Rigidbody2D>().gravityScale = -1;
        }

        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
