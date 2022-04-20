using System.Diagnostics;

namespace Task_17_Librarry
{
    public static class Cycles
    {
        static List<Car> list = new List<Car>();
        static Stopwatch stopWatch = new Stopwatch();
        static Random random = new Random();

        public static void LoadList(int count)
        {
            for (int i = 0; i < count; i++)
                list.Add(new Car() { Age = random.Next() });
        }
        static void ChangeAge(int count)
        {
            list[count].Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
        }
        static void Print(string x)
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                            ts.Hours, ts.Minutes, ts.Seconds,
                                            ts.Milliseconds);
            Console.WriteLine($"Run time in {x}:\n\t" + elapsedTime);
        }
        public static void CycleFor()
        {
            stopWatch.Start();
            for (int i = 0; i < list.Count; i++)
                ChangeAge(i);
            Print("For");
        }
        public static void CycleForeach()
        {
            stopWatch.Start();
            foreach (var item in list)
                item.Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
            Print("Foreach");
        }
        public static void CycleParallelFor()
        {
            stopWatch.Start();
            Parallel.For(0, list.Count, ChangeAge);
            Print("Parallel For");
        }
        public static void CycleParallelForeach()
        {
            stopWatch.Start();
            Parallel.ForEach(list, item =>
            {
                item.Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute; ;
            });
            Print("Parallel Foreach");
        }
    }
}
