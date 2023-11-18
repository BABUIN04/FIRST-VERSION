using UnityEngine;

public class PlatformCallingButton : MonoBehaviour, Iinteract
{
    public MoveToPoint movetopoint;
    public void interact()
    {
        if(movetopoint.NumberOfPoint == 0)
        {
            movetopoint.NumberOfPoint = 1;
        }
        else
        {
            movetopoint.NumberOfPoint = 0;
        }
        movetopoint.DoMove = true;
    }
}
