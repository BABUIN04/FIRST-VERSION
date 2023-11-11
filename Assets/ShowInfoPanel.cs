using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowInfoPanel : MonoBehaviour
{
    public TextMeshPro info;
    private void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        info.text = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Iinteract interact = collision.GetComponent<Iinteract>();
        if (interact != null)
        {
            info.text = "Нажмите Е чтобы взаимодействовать";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        info.text = null;
    }
}
