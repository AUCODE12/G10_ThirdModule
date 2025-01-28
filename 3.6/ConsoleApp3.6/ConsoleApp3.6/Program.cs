using System;

namespace ConsoleApp3._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpApi = new MusicCrudApiBroker();
            var music = new Music()
            {
                Name = "dsfsdfsdf",
                MB = 4.82,
                AuthorName = "dsfsdfsdf Jo'nbbjkbkjbnkjbkj",
                Description = "Yaxshi",
                QuentityLikes = 4554
            };
            //httpApi.Add(music);
            httpApi.GetAll();
        }



        public static void TupleInfo()
        {
            var res = GetMaxMin(43, 23, 33);
            Console.WriteLine(res.Item1);
            Console.WriteLine(res.Item2);
            Console.WriteLine(res);
        }

        public static (int, int) GetMaxMin(int a1, int a2, int a3)
        {
            var maxNum = Math.Max(a1, Math.Max(a2,a3));
            var minNum = Math.Min(a1, Math.Min(a2,a3));

            var res = (maxNum,  minNum);
            return res;
        }
    }
}
