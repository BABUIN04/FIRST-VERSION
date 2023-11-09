using UnityEngine;

public class MapStarter : MonoBehaviour, Iinteract
{
    public GameObject map;
    private Player player;
    private GameObject playerObj;
    private bool IsShowing = false;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        map.SetActive(false);
    }

    public void DisActive()
    {
        map.SetActive(false);
        IsShowing = false;
        player.CanMove = true;
    }
    public void Activate()
    {
        map.SetActive(true);
        IsShowing = true;
        player.CanMove = false;
    }
    public void interact()
    {
        if (IsShowing)
        {
            DisActive();
        }
        else
        {
            Activate();
        }
    }
}
