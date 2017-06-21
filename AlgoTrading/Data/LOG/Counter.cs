
namespace AlgoTrading.Data.LOG
{
    public class Counter
    {
        private static int LoopCounter { get; set; }
        private static readonly object locker = new object();

        //return a string represet of the numbers of times the this function called
        public override string ToString()
        {
            lock (locker)
            {
                LoopCounter = LoopCounter + 1;
                return LoopCounter.ToString();
            }
        }
    }
}
