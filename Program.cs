using static System.Console;
using System;

namespace ProjectPlanAPettingZooVisit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*There are currently three visiting schools
             * School A has six visiting groups (the default number)
             * School B has three visiting groups
             * School C has two visiting groups
             * For each visiting school, perform the following tasks
             
             * Randomize the animals
             * Assign the animals to the correct number of groups
             * Print the school name
             * Print the animal groups */

            string[] pettingZoo =
            {
                "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
                "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
                "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
            };

            PlanSchoolVisit("School A");
            PlanSchoolVisit("School B", 3);
            PlanSchoolVisit("School C", 2);

            void PlanSchoolVisit(string schoolName, int groups = 6)
            {
                RandomizeAnimals();
                string[,] group1 = AssignGroup(groups);
                WriteLine(schoolName);
                PrintGroup(group1);
            }

            void RandomizeAnimals()
            {

                Random random = new Random();

                for (int i = 0; i < pettingZoo.Length; i++)
                {
                    int r = random.Next(i, pettingZoo.Length);

                    string temp = pettingZoo[i];
                    pettingZoo[i] = pettingZoo[r];
                    pettingZoo[r] = temp;
                }
            }

            //foreach (string animal in pettingZoo)
            //{
            //    WriteLine(animal);
            //}

            string[,] AssignGroup(int groups = 6)
            {
                string[,] result = new string[groups, pettingZoo.Length / groups];
                int start = 0;

                for (int i = 0; i < groups; i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = pettingZoo[start++];
                    }
                }

                return result;
            }

            void PrintGroup(string[,] group)
            {
                for (int i = 0; i < group.GetLength(0); i++)
                {
                    Write($"Group {i + 1}: ");

                    for (int j = 0; j < group.GetLength(1); j++)
                    {
                        Write($"{group[i, j]}  ");
                    }
                    WriteLine();
                }

            }

            ReadKey();
        }
    }
}
