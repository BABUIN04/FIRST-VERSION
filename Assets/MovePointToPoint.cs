public class MovePointToPoint : MoveToPoint
{
    public override void Finish()
    {
        if(NumberOfPoint == 1)
        {
            NumberOfPoint = 0;
        }
        else
        {
            NumberOfPoint = 1;
        }
    }
}
