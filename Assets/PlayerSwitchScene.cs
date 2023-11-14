using UnityEngine;

public class PlayerSwitchScene : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Vector3 PlayerPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            player.transform.position = PlayerPosition;
        }
    }
}
