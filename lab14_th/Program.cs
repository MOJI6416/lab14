using System;
using System.IO;
using System.Threading;


namespace lab14_th
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };
            int[] array3 = { 7, 8, 9 };

            SaveAsThread saveArray1 = new SaveAsThread(array1, "array1.txt");
            SaveAsThread saveArray2 = new SaveAsThread(array2, "array2.txt");
            SaveAsThread saveArray3 = new SaveAsThread(array3, "array3.txt");

            saveArray1.Run();
            saveArray2.Run();
            saveArray3.Run();
            Console.ReadKey();
        }
    }

    public class SaveAsThread
    {
        private readonly int[] array;
        private readonly string fileName;

        public SaveAsThread(int[] array, string fileName)
        {
            this.array = array;
            this.fileName = fileName;
        }

        public void SaveArrayToFile()
        {
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    foreach (var item in array)
                    {
                        writer.WriteLine(item);
                    }
                }
                Console.WriteLine($"Array saved to file {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving array to file {fileName}: {ex.Message}");
            }
        }

        public void Run()
        {
            Thread thread = new Thread(SaveArrayToFile);
            thread.Start();
        }
    }
}
