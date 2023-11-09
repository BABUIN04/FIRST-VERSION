using UnityEngine;

public class BlackScreenTrigger : MonoBehaviour, Iinteract
{
    private BlackScreen blackscreen;
    public string SceneWayName;
    public void interact()
    {
        blackscreen = GameObject.FindGameObjectWithTag("BlackScreen").GetComponent<BlackScreen>();
        blackscreen.StartBlackScreen(SceneWayName);
    }
}
