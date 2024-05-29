using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public GameObject rocket;

    void Start()
    {
        
    }


    void Update()
    {

        if (player.activeSelf)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z);
        }
    }
}
