using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public Image image;
    private int x = 1;
    public void StartBlackScreen()
    {
        StartCoroutine(BlackScreenFunc());
    }
    public IEnumerator BlackScreenFunc()
    {
        var tempColor = image.color;
        for (; tempColor.a < 1.5f; tempColor.a += x * Time.deltaTime)
        {
            image.color = tempColor;
            yield return new WaitForEndOfFrame(); 
        }
        x = -1;
        Debug.Log("Сработало!");//сюда логику сцен
        for(; tempColor.a > 0; tempColor.a += x * Time.deltaTime)
        {
            image.color = tempColor;
            yield return new WaitForEndOfFrame();
        }
        x = 1;
    }
}
