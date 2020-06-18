using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Graf

{
    // Функция для печати матрицы смежности.
    static void printMat(int[] degseq, int n)
    {
        // n - количество вершин
        int[,] mat = new int[n, n];
        // Студенты, которым пришло сообщение.
        int[,] know = new int[n, n];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (degseq[i] > 0 && degseq[j] > 0)
                {
                    degseq[i]--;
                    degseq[j]--;
                    mat[i, j] = 1;
                    mat[j, i] = 1;
                    sum++;
                }
            }
        }
        
        // Печать результата
        Console.Write("\n" + setw(3) + "     ");

        for (int i = 0; i < n; i++)
            Console.Write(setw(3) + "(" + (i + 1) + ")");

        Console.Write("\n\n");

        for (int i = 0; i < n; i++)
        {
            Console.Write(setw(4) + "(" + (i + 1) + ")");

            for (int j = 0; j < n; j++)
                Console.Write(setw(5) + mat[i, j]);

            Console.Write("\n");
        }

        Console.WriteLine("Список смежности: ");
        Console.WriteLine(sum);
        // Вывод списка пересылок.
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i, j] == 1 && know[j, i] != 1) {
                    Console.WriteLine(((i+1) + ": "+ (j+1)));
                    know[i, j] = 1;
                    know[j, i] = 1;
                }
                
            }
        }
    }

    static String setw(int n)
    {

        String space = "";

        while (n-- > 0)
       
            space += " ";
        return space;

    }
    
    public static void Main(String[] args)
    {
        try
        {
            // Считывание кол-ва человек.
            string count = File.ReadLines("C:/Users/user/source/repos/TaskForSoftius/TaskForSoftius/Res/input.txt").First();
            // Кол-во сообщений у каждого.
            string messages = File.ReadLines("C:/Users/user/source/repos/TaskForSoftius/TaskForSoftius/Res/input.txt").Skip(1).First();
       
            string[] mass = messages.Split(' ');

            int n = Convert.ToInt16(count);
            int[] degseq = new int[n];

            for (int i = 0; i < mass.Length; i++) {
                degseq[i] = Convert.ToInt16(mass[i]);

                if (degseq[mass.Length - 1] == 0) {
                    degseq[mass.Length - 1] = 1;
                }

                if (i != 0 && i != (mass.Length - 1)) {
                    degseq[i] = degseq[i] + 1;
                }
            }

            if (degseq[0] != -1)
            {
                printMat(degseq, n);
                Console.ReadKey();
            }
            else {

                Console.WriteLine(-1);
                Console.ReadKey();
            }
       
       
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}