using Task_17_Librarry;

namespace Task_17
{
    public class Program
    {
        const int CountElement = 100000;
        public static void Main(string[] args)
        {
            Cycles.LoadList(CountElement);
            Cycles.CycleFor();
            Cycles.CycleForeach();
            Cycles.CycleParallelFor();
            Cycles.CycleParallelForeach();
        }
    }
}