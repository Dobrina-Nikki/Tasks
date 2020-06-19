using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Graf

{

    class Item {
        public int a;
        public int n;
        public bool used;
    }

    class Pair {
        public int a;
        public int b;
    }
    class MessageComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            if (x.a > y.a)
            {
                return -1;
            }
            else if (x.a < y.a) {
                return 1;
            }
            return 0;
        }
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

            List<Item> list = new List<Item>();
            
            for (int i = 0; i < mass.Length; i++) {

                Item person = new Item();
                person.a = Convert.ToInt16(mass[i]);
                person.n = i + 1;
                person.used = false;
                list.Add(person);
            }

            MessageComparer nc = new MessageComparer();
           
            list.Sort(1,n-1,nc);

            int us = 1;
            list[0].used = true;
            List <Pair> ans = new List<Pair>();
            int cnt = 0;

            for (int i = 0; i < n; i++) {
                if (list[i].used){
                    for (; us < n && list[i].a > 0; list[i].a--, us++)
                    {
                        Pair forAnswer = new Pair();
                        list[us].used = true;
                        forAnswer.a = list[i].n;
                        forAnswer.b = list[us].n;
                        ans.Add(forAnswer);
                    }
                }
                else {
                    Console.WriteLine("-1");
                    return;
                }
            }
            Console.WriteLine(n - 1);
            for (int i = 0; i < n - 1; i++) {
                Console.WriteLine(ans[i].a + " " + ans[i].b);
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}