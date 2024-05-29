using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject pauseMenu;
    public bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<SpriteRenderer>().flipX == false && isPaused == false)
        {
            bullet.GetComponent<Bullet>().direction = 1;
            GameObject ballGO = Instantiate(bullet);
            ballGO.transform.position = new Vector3(player.GetComponent<Transform>().position.x + 1, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<SpriteRenderer>().flipX == true && isPaused == false)
        {
            bullet.GetComponent<Bullet>().direction = -1;
            GameObject ballGO = Instantiate(bullet);
            ballGO.transform.position = new Vector3(player.GetComponent<Transform>().position.x - 1, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("lvl1");
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ChooseMission()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void lvl1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("lvl1");
    }

    public void lvl2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("lvl2");
    }

    public void lvl3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void Leave()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main_menu");
    }


}
