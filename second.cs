using System;
using System.Text.RegularExpressions;



namespace ConsoleApp10

{

    class skiManOld
    {

        public string fam;

        public int res;

        public skiManOld(string fami, int resi)

        {

            fam = fami;

            res = resi;

        }

    }

    class skiMan : skiManOld
    {

        public string fam;

        public int res;

        public int rating;

        public skiMan(string fami, int resi) : base(fami, resi)
        {
            fam = fami;

            res = resi;
            if (res >= 30) {
                rating = 5;
            } else if (res >= 20)
            {
                rating = 4;
            } else if (res >= 10) {
                rating = 3;
            }
        }
    }



    class Program

    {

        static void bubbleSort(skiMan[] group1)

        {

            for (int i = 0; i < group1.Length - 1; i++)

            {

                for (int j = i + 1; j < group1.Length; j++)

                {

                    if (group1[i].res > group1[j].res)

                    {

                        skiMan temp = group1[i];
                        group1[i] = group1[j];

                        group1[j] = temp;

                    }

                }

            }

        }



        static skiMan[] merge(skiMan[] group1, skiMan[] group2)

        {

            int a = 0, b = 0;

            skiMan[] merged = new skiMan[group1.Length + group2.Length];

            for (int i = 0; i < group1.Length + group2.Length; i++)

            {

                if (b < group2.Length && a < group1.Length)

                    if (group1[a].res > group2[b].res)
                        merged[i] = group2[b++];

                    else

                        merged[i] = group1[a++];

                else

                if (b < group2.Length)

                    merged[i] = group2[b++];

                else

                    merged[i] = group1[a++];

            }

            return merged;

        }

        static void Main(string[] args)

        {

            skiMan[] group1 = { new skiMan("groupperA1", 20), new skiMan("groupperA2", 30), new skiMan("groupperA3", 60) };

            skiMan[] group2 = { new skiMan("groupperB1", 10), new skiMan("groupperB2", 50), new skiMan("groupperB3", 25) };

            bubbleSort(group1);

            bubbleSort(group2);

            skiMan[] table = merge(group1, group2);

            Console.WriteLine("COMPETITION RESULTS:\n —------------------------— \n");

            for (int i = 0; i < table.Length; i++)

            {

                Console.WriteLine($"Name: {table[i].fam} RESULT: {table[i].res}");

            }

            Console.WriteLine("\n —------------------------— \n");


            Console.ReadKey();
        }

    }

}
