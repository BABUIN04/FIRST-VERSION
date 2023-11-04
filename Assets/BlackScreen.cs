using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{
    public Image image;
    private int x = 1;
    public IEnumerator BlackScreenFunc()
    {
        var tempColor = image.color;
        for (; tempColor.a < 1.5f; tempColor.a += x * Time.deltaTime)
        {
            image.color = tempColor;
            yield return new WaitForEndOfFrame(); 
        }
        SceneManager.LoadScene("hub");
        x = -1;
        for (; tempColor.a > 0; tempColor.a += x * Time.deltaTime)
        {
            image.color = tempColor;
            yield return new WaitForEndOfFrame();
        }
    }
}
