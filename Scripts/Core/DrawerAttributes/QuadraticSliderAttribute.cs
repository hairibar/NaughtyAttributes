namespace NaughtyAttributes
{
    public class QuadraticSliderAttribute : DrawerAttribute
    {
        public int Power { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }

        public QuadraticSliderAttribute(int min, int max, int power)
        {
            Min = min;
            Max = max;
            Power = power;
        }
    }

}
