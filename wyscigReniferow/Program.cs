namespace wyscigReniferow
{
    internal class Program
    {
        public class Reindeer
        {
            public int order { get; set; }
            public int speed { get; set; }
            public int runTime { get; set; }
            public int breakTime { get; set; }

            public Reindeer(int order, int speed, int runTime, int breakTime)
            {
                this.order = order;
                this.speed = speed;
                this.runTime = runTime;
                this.breakTime = breakTime;
            }
        }

        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int n);
            List<Reindeer> reindeers = new List<Reindeer>();
            int order = 1;
            for(int i = 0; i < n; i++)
            {
                string[] stats = Console.ReadLine().Split(' ');
                reindeers.Add(new Reindeer(order, int.Parse(stats[0]), int.Parse(stats[1]), int.Parse(stats[2])));
                order++;
            }

            int.TryParse(Console.ReadLine(), out int t);
            int biggestDistance = 0;

            foreach(Reindeer r in reindeers)
            {
                int distance = 0;
                int time = 0;

                while(time < t)
                {
                    if((time+r.runTime) > t)
                    {
                        distance += r.speed * (r.runTime - (time + r.runTime - t));
                        break;
                    }

                    distance += r.speed * r.runTime;
                    time += r.runTime + r.breakTime;
                }

                if(distance > biggestDistance)
                {
                    biggestDistance = distance;
                    order = r.order;
                }
            }

            Console.WriteLine(order);
        }
    }
}
