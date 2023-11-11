using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{
    public static BlackScreen instance { get; private set; }
    public Image image;
    private int x = 1;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this.gameObject);
    }
    public void StartBlackScreen(string SceneWayName)
    {
        x = 1;
        StartCoroutine(BlackScreenFunc(SceneWayName));
    }
    private IEnumerator BlackScreenFunc(string SceneWayName)
    {
        var tempColor = image.color;

        for (; tempColor.a < 1.5f; tempColor.a += x * Time.deltaTime)
        {
            image.color = tempColor;
            yield return new WaitForEndOfFrame(); 
        }

        SceneManager.LoadScene(SceneWayName);

        x = -1;
        for (; tempColor.a > 0; tempColor.a += x * Time.deltaTime)
        {
            image.color = tempColor;
            yield return new WaitForEndOfFrame();
        }
    }
}
