using UnityEngine;

public class MapSwitcher : MonoBehaviour
{
    private BlackScreen blackscreen;
    public string SceneWayName;
    [SerializeField] MapStarter mapStarter;
    public void OnClick()
    {
        mapStarter.DisActive();
        blackscreen = GameObject.FindGameObjectWithTag("BlackScreen").GetComponent<BlackScreen>();
        blackscreen.StartBlackScreen(SceneWayName);
    }
}
