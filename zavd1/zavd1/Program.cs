using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zavd1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1;
            string line2;
            int line1_number, line2_number;
            int product = new Int32();
            long sum = 0;
            int corrfiles = 0;
            for (int i = 10; i < 30; i++)
            {
                string path = @"D:\University\ООП\4 laba\zavd1\zavd1\txt\" + i + ".txt";
                try
                {
                    StreamReader f = new StreamReader(path);
                    line1 = f.ReadLine();
                    line1_number = Convert.ToInt32(line1);
                    line2 = f.ReadLine();
                    line2_number = Convert.ToInt32(line2);
                    checked
                    {
                        product = line1_number * line2_number;
                    }
                    Console.WriteLine("Добуток чисел в файлi " + i + ".txt" + " = " + product);
                    sum += product;
                    corrfiles++;
                    f.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    using (StreamWriter no_file = new StreamWriter(@"D:\University\ООП\4 laba\zavd1\zavd1\txt\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        no_file.WriteLine(i + ".txt");
                    }
                }
                catch (System.FormatException)
                {
                    using (StreamWriter bad_data = new StreamWriter(@"D:\University\ООП\4 laba\zavd1\zavd1\txt\bad_data.txt", true, System.Text.Encoding.Default))
                    {
                        bad_data.WriteLine(i + ".txt");
                    }
                }
                catch (System.OverflowException)
                {
                    using (StreamWriter overflow = new StreamWriter(@"D:\University\ООП\4 laba\zavd1\zavd1\txt\overflow.txt", true, System.Text.Encoding.Default))
                    {
                        overflow.WriteLine(i + ".txt");
                    }
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Немає доступу до файлу. Можливо його вже було створено");
                    break;
                }
            }
            Console.WriteLine("Cереднє арифметичне коректних файлiв: {1}", corrfiles, sum / (double)corrfiles);
            Console.ReadKey();
        }
    }
}