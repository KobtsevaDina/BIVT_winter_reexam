// Variant_9
using System;
using System.Net.Http.Headers;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();

            //1
            double answer1 = program.Task_1(4,6,22);
            //Console.WriteLine(answer1);

            //2
            double answer2 = program.Task_2(4, 6, 22);
            //Console.WriteLine(answer2);

            //3
            int[,] testmatrix = new int[,] { { 23, 7, -13, 24, -21, 18 }, { 2, 0, 12, -16, -20, -17 }, { 22, 21, -6, 19, -22, -4 }, { -13, 13, 18, -15, -20, -2 }, { 3, 7, 1, -20, 22, -8 }, { -22, -11, 13, -2, 0, -14 } };
            //program.print_matrix(testmatrix);
            program.Task_3(testmatrix);
            //program.print_matrix(testmatrix);

            //4
            int[] testarray = new int[] { 17, 17, 2, -10, -1, -20 };
            //program.print_array(testarray);
            program.Task_4(ref testarray);
            //program.print_array(testarray);






        }
        public double Task_1(double T, double D, double N)
        {
            if (T < 0 || D < 0 || N < 1)
            {
                return 0;
            }

            double time = 9 + T;             //время, прошедшее после запуска ПЕРВОГО заклинания
            double timeout = 10;             //перезарядка заклинания
            int knights = 0;                 //счетчик вернувшихся рыцарей
            double returning = T;            //время, требующееся для возвращения очередного рыцаря
            double catching_timer = T+9;     //время, прошедшее с запуска предыдущего заклинания

            while (knights != N)
            {
                time++;
                catching_timer++;

                if (catching_timer == timeout + returning)
                {
                    knights++;      //предыдущий рыцарь

                    //запуск нового заклинания
                    returning = time + T;   
                    timeout += D;
                    catching_timer = 0;
                }

            }

            return time-(timeout-D);
        }
        public double Task_2(double speedLimit, double motorLimit, double turnsPerSec)
        {
            if (speedLimit <= 0 || motorLimit <= 0 || turnsPerSec <= 0)
            {
                return 0;
            }
            double speed = 0;
            double turns = 0;
            int gear = 1;
            double time = 0;

            while (speed < speedLimit)
            {
                if (turns < motorLimit)
                {
                    turns += turnsPerSec;
                    time += 0.5;
                }
                else if (gear >= 5)
                { 
                    turns = motorLimit;
                }
                else
                {
                    gear++;
                    turns -= turns * 0.15;
                    time++;
                    motorLimit += 250;
                }

                turns = Math.Round(turns);
                speed += turns / 180;
                time += 0.1;
            }

            return time;
        }
        public void Task_3(int[,] M)
        {
            if (M == null || M.GetLength(0) != M.GetLength(1))
            {
                return;
            }

            int length = M.GetLength(0);
            int a;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length-1-i; j++)
                {
                    if (i != j)
                    {
                        a = M[i,j];
                        M[i, j] = M[length - 1 - i, length - 1 - j];
                        M[length - 1 - i, length - 1 - j] = a;
                    }
                }
            }
        }
        public void Task_4(ref int[] A)
        {
            if (A == null)
            {
                return;
            }

            A = GetNegativeSubArray(A);
        }
        public int[] GetNegativeSubArray(int[] array)
        {
            int cnt=0;
            int c = 0;
            int new_index;

            foreach (int i in array)
            {
                if (i < 0)
                {
                    cnt++;
                }
            }

            int[] negative_array = new int[cnt];

            foreach (int i in array)
            {
                if (i < 0)
                {
                    negative_array[c] = i;
                    c++;
                }
            }

            int[] new_negative_array = new int[cnt];

            for (int i = 0; i < cnt; i++)
            {
                new_index = (i + 10) % cnt;
                new_negative_array[new_index] = negative_array[i];
            }

            return new_negative_array; 
        }
        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {

        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array) { }
        public void SortDescending(int[] array) { }
        public void FindUpperPartMaxIndex(int[,] matrix, out int maxRow, out int maxCol)
        {
            maxRow = 0; maxCol = 0;
        }
        public void FindLowerPartMinIndex(int[,] matrix, out int minRow, out int minCol)
        {
            minRow = 0; minCol = 0;
        }


        public void print_array(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void print_matrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}