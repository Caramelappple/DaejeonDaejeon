namespace _LSO._Scripts.Laser.Interface
{
    public class EvaluateCalculator : IEvaluate
    {
        public float Evaluate(UpgradeStat[] data, float percentage)
        {
            if (data.Length == 0)
                return 0f;
            
            
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if ( (percentage >= data[i].percent))
                    return data[i].value;
            }
            return 0f;
        }
    }
}