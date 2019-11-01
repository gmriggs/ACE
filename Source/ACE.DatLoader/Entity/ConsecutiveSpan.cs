namespace ACE.DatLoader.Entity
{
    // helper, not defined explicitly in original ac data
    public class ConsecutiveSpan
    {
        public int NegSize;
        public int StartIteration;

        public ConsecutiveSpan(int negSize, int startIteration)
        {
            NegSize = negSize;
            StartIteration = startIteration;
        }

        public override string ToString()
        {
            return $"{NegSize}, {StartIteration}";
        }
    }
}
