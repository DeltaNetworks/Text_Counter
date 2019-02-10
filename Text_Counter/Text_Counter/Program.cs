using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text_Counter
{
    class Program
    {
        public static object Assert { get; private set; }

        static void Main(string[] args)
        {
            string folder_path = @"E:\Logs";

            string[] words = new string[] { "error", "fatal" };
            Search_All_Files(words, folder_path);
        }

        private static void Search_All_Files(string[] words, string folder_path)
        {
            string[] all_files_list = Directory.GetFiles(folder_path, "*.log");
            ArrayList array_result = new ArrayList();
            // first loop is run according to words array
            foreach (string word in words)
            {
                int counter = 0;
                //string all_text = File.ReadAllText(current_file);
                //all_text.Contains()
                foreach (string current_file in all_files_list)
                {
                    counter = 0;
                    string[] all_line = File.ReadAllLines(current_file);

                    foreach (string line in all_line)
                    {
                        foreach (Match word_match in Regex.Matches(line, word))
                        {
                            counter++;
                        }
                    }
                    array_result.Add(current_file + ";" + word + ";" + counter.ToString());
                }
            }
            Create_Html(array_result);
        }

        private static void Create_Html(ArrayList array_result)
        {
            throw new NotImplementedException();
        }
    }
}
