using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Soad1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arrayWords = (File.ReadAllText("./big.txt")).Replace("\n", " ").Split(' ');
            arrayWords = arrayWords.Where(s => s != "").ToArray();


            Dictionary<string, int> qw1;
            List<KeyValuePair<string, int>> qw2;
            SortedDictionary<string, int> qw3;
          


            Stopwatch stopWatch;
            TimeSpan time;
            // ----------------------------------------- Dictionary
            stopWatch = new Stopwatch();
            stopWatch.Start();
            Sorted(out qw1, arrayWords);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            Console.WriteLine(time.Milliseconds);
            // -----------------------------------------
            // ----------------------------------------- List
            stopWatch = new Stopwatch();
            stopWatch.Start();
            Sorted(out qw1, arrayWords);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            Console.WriteLine(time.Milliseconds);
            // -----------------------------------------
            // ----------------------------------------- SortedDictionary
            stopWatch = new Stopwatch();
            stopWatch.Start();
            Sorted(out qw1, arrayWords);
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            Console.WriteLine(time.Milliseconds);
            // -----------------------------------------


            Console.ReadLine();
        }
        static void Sorted(out Dictionary<string, int> dict, string[] arr) 
        {
            dict = new Dictionary<string, int>();
            foreach (string theWord in arr)
            {
                if (dict.ContainsKey(theWord))
                {
                    dict[theWord] += 1;
                    continue;
                }
                dict.Add(theWord, 1);
            }
        }
        static void Sorted(out List<KeyValuePair<string, int>> list, string[] arr) 
        {
            list = new List<KeyValuePair<string, int>>();

            list.Add(new KeyValuePair<string, int>(arr[0], 1));
            foreach (string theWord in arr)
            {
                if (list.TrueForAll(elm => elm.Key == theWord))
                {
                
                    KeyValuePair<string, int> pair = list[list.FindIndex(s => s.Key == theWord)];
                    list[list.FindIndex(s => s.Key == theWord)] = new KeyValuePair<string, int>(pair.Key, pair.Value + 1);
                    continue;
                }
                list.Add(new KeyValuePair<string, int>(theWord, 1));
            }
        }
        static void Sorted(out SortedDictionary<string, int> dict, string[] arr) 
        {
            dict = new SortedDictionary<string, int>();
            foreach (string theWord in arr)
            {
                if (dict.ContainsKey(theWord))
                {
                    dict[theWord] += 1;
                    continue;
                }
                dict.Add(theWord, 1);
            }
        }
    }
}
