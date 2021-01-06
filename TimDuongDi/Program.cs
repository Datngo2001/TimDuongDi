using System.Collections.Generic;
using System;

namespace TimDuongDi
{
    class Program
    {
        public const int max = 9;
        public static int[,] m = new int[,]
        {
            {0, 1, 1, 0, 0, 0, 0, 0, 0},
            {1, 0, 1, 0, 0, 0, 0, 0, 1},
            {1, 1, 0, 1, 1, 0, 0, 0, 0},
            {0, 0, 1, 0, 1, 0, 0, 0, 1},
            {0, 0, 1, 1, 0, 1, 1, 0, 0},
            {0, 0, 0, 0, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 0, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 0},
            {0, 1, 0, 1, 0, 0, 0, 0, 0},
        };
        public static bool[] chuaxet = new bool[max];
        public static bool[,] ke = new bool[max, max];
        public static int[] truoc = new int[max];
        // tim duong di theo chieu sau su dung de quy
        public static void DFSdequy(int v)
        {
            //duyet dinh v
            chuaxet[v] = false;
            for (int u = 0; u < max; u++)
            {
                if (ke[u, v] == true && chuaxet[u] == true)
                {
                    truoc[u] = v;
                    DFSdequy(u);
                }
            }
        }
        // tim duong di theo chieu rong su dung QUEUE
        public static void BFSqueue(int v)
        {
            Queue<int> QUEUE = new Queue<int>();
            QUEUE.Enqueue(v);
            chuaxet[v] = false;
            while (QUEUE.Count != 0)
            {
                int p = QUEUE.Dequeue();
                // Duyet dinh p
                chuaxet[p] = false;
                for (int u = 0; u < max; u++)
                {
                    if (ke[u, p] == true && chuaxet[u] == true)
                    {
                        QUEUE.Enqueue(u);
                        chuaxet[u] = false;
                        truoc[u] = p;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // tao mang ke
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (m[i, j] == 1)
                    {
                        ke[i, j] = true;
                    }
                }
            }
            // tao nhan cho dinh
            for (int i = 0; i < max; i++)
            {
                chuaxet[i] = true;
            }
            // Diem dau va diem ket thuc
            int s, t; 
            s = 0;
            t = 8;

            // tim duong di theo chieu sau su dung de quy (co huong va vo huong deu dc)
            DFSdequy(s);
            if(chuaxet[t] == true)
            {
                Console.WriteLine("Khong co duong di tu " + s + " den " + t);
            }
            else
            {
                Console.Write("Co duong di tu " + s + " den " + t + " la: ");
            }

            // tim duong di theo chieu rong su dung QUEUE
            BFSqueue(s);
            if (chuaxet[t] == true)
            {
                Console.WriteLine("Khong co duong di tu " + s + " den " + t);
            }
            else
            {
                Console.Write("Co duong di tu " + s + " den " + t + " la: ");
            }
        }
    }
}
