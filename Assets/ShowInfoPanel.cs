using UnityEngine;
using TMPro;

public class ShowInfoPanel : MonoBehaviour
{
    public TextMeshPro info;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interactable")
        {
            info.text = collision.name;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "interactable")
        {
            info.text = null;
        }
    }
}
