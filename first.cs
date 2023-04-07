using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class group
    {
        public string groupname;
        public double srg;
        public group(string groupnamein, double srgin) { 
            groupname = groupnamein;
            srg = srgin;
        }
    }
    public class studentbase
    {
        public int[] marks;
        public string fam;
        public double sr;
        public studentbase(string famin, int[] marksin) {
        fam = famin;
            marks = marksin;
            int sum = 0;
            for (int i = 0; i < marksin.Length; i++)
            {
                sum += marksin[i];
            }
            sr = (double)sum / marksin.Length;
        }
    }

    public class student : studentbase
    {
        public int money;
        public student(string famin, int[] marksin) : base(famin, marksin)
        {
            fam = famin;
            marks = marksin;
            int sum = 0;
            for (int i = 0; i < marksin.Length; i++)
            {
                sum += marksin[i];
            }
            sr = (double)sum / marksin.Length;
            if (sr > 4)
            {
                money = 1500;
            }
        }
    }
    internal class Program
    {
        static student[] sortGroup(student[] group1) {
            for (int i = 0; i < 2; i++)
            {
                for (int j = i+1; j < 3; j++)
                {
                    student temp;
                    if (group1[i].sr < group1[j].sr)
                    {
                        temp = group1[i];
                        group1[i] = group1[j];
                        group1[j] = temp;
                    }
                }
            }
            return group1;
        }
        
        static double getSrg(student[] group1) {
            double srg = 0, sum = 0;
            for (int i = 0; i < group1.Length; i++)
            {
                sum += group1[i].sr;
            }
            srg = sum / group1.Length;
            return srg;
        }
        static void showGroup(student[] group1, string groupname)
        {
            Console.WriteLine($"\n{groupname}\n");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Name: {group1[i].fam} Marking: {group1[i].sr}");
            }
        }
        static void Main(string[] args)
        {
            student[] group1 = { new student("stud1A", new int[] { 3, 3, 3 }), new student("stud1B", new int[] { 5, 5, 5 }), new student("stud1C", new int[] { 5, 5, 5 }) };
            student[] group2 = { new student("stud2A", new int[] { 4, 4, 4 }), new student("stud2B", new int[] { 4, 4, 4 }), new student("stud2C", new int[] { 5, 5, 5 }) };
            student[] group3 = { new student("stud3A", new int[] { 4, 4, 4 }), new student("stud3B", new int[] { 3, 3, 3 }), new student("stud3C", new int[] { 3, 3, 3 }) };
            group1 = sortGroup(group1);
            group2 = sortGroup(group2);
            group3 = sortGroup(group3);

            group[] groups = { new group("Group 1", getSrg(group1)), new group("Group 2", getSrg(group2)), new group("Group 3", getSrg(group3)) };

            showGroup(group1, "Group 1");
            showGroup(group2, "Group 2");
            showGroup(group3, "Group 3");

            Console.WriteLine("\nSorted:\n");

            for (int i = 0; i < groups.Length-1; i++)
            {
                for (int j = i+1; j < groups.Length; j++)
                {
                    if (groups[i].srg < groups[j].srg)
                    {
                        group temp = groups[i];
                        groups[i] = groups[j];
                        groups[j] = temp;
                    }
                }
            }

            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"{groups[i].groupname} Mark: {groups[i].srg}");
            }

            Console.ReadKey();
        }
    }
}
