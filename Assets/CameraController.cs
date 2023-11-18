using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float XLimitterRight;
    [SerializeField] float XLimitterLeft;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x, XLimitterLeft, XLimitterRight), transform.position.y, transform.position.z);

    }
}
