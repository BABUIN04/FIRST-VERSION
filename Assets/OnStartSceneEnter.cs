using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStartSceneEnter : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "StartScene")
        {
            this.transform.position = new Vector2(-6.2f, -2.39f);
        }
    }
}
