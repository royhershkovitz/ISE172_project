
namespace AlgoTrading.Data.LOG
{
    public class Counter
    {
        private static int LoopCounter { get; set; }

        public override string ToString()
        {
            LoopCounter = LoopCounter + 1;
            return LoopCounter.ToString();
        }
    }
}
