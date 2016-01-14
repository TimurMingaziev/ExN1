using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExN1
{
    public class SuperClass
    {
        List<int> numbers = new List<int>();
        
        // Забираем со строки только числа.
        void parsString(string fullstr)
        {

            string[] stringOfInt = fullstr.Split(',');
            try
            {
                foreach (string s in stringOfInt)
                    numbers.Add(Convert.ToInt32(s));
            }
            catch(Exception e){
                Console.WriteLine("Ошибка, скорее всего файл заполнен не верно " + '\n' + e.Message);
            }
        }

        // Сортировка массива в обратном порядке.
        // numbers.Reverse(); 
        public List<int> sortMas() 
        {
            int driver = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                driver = numbers.ElementAt(i);
                numbers.Insert(i, numbers.ElementAt((numbers.Count - 1) - i));
                numbers.Insert(((numbers.Count - 1) - i), driver);
                numbers.RemoveAt(i + 1);
                numbers.RemoveAt((numbers.Count - 1) - i);
            }
            return numbers;
        }

        // Считываем массив с файла.
        public void readFileWhisMas()
        {
            FileStream file = null;
            string str = "";
            string fullstr = "";// Содержит весь массив.
            try
            {
                file = new FileStream("masFile.txt", FileMode.Open);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            StreamReader reader = (file != null) ? new StreamReader(file) : null;
            if (reader != null)
            {
                try
                {
                    Console.WriteLine("Our mas: " + '\n');
                    Console.Write(fullstr = reader.ReadToEnd());
                    Console.WriteLine('\n');
                }
                catch (IOException e) { Console.WriteLine(e.Message); }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
            parsString(fullstr);
        }

        // Запись отсортированного массива в файл.
         public void writeFile(List<int> m)
         {

             StreamWriter writer = null;
             try
             {
                 writer = new StreamWriter("sortedMasFile.txt");
             }
             catch (IOException e ){Console.WriteLine(e.Message); }
             if (writer != null)
             {
                 try
                 {
                     for (int i = 0; i < m.Count; i++)
                     {
                         if (i != m.Count - 1)
                             writer.Write(m.ElementAt(i).ToString() + ",");
                         else writer.Write(m.ElementAt(i).ToString());
                     }
                 }
                 catch (IOException e){Console.WriteLine(e.Message); }
                 finally
                 {
                     if (writer != null)
                         writer.Close();
                 }
             }
         }
    }
}
