using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInHub : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            player.transform.position = new Vector3(8,-2,0);
        }
    }
}
