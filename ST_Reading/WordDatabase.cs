using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ST_Reading
{
    class WordDatabase
    {
        List<string> wordlist;
        Window screen;
        public int WordCount { get; set; }
        public WordDatabase(Window window)
        {
            WordCount = 1000;
            screen = window;
            wordlist = new List<string>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ST_Reading.wordlist.txt");
            StreamReader streamReader = new StreamReader(stream);
            while (!streamReader.EndOfStream)
            {
                wordlist.Add(streamReader.ReadLine());
            }
            //MessageBox.Show("Lines Read: " + wordlist.Count);
        }
        public void FillWithText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < WordCount; i++)
            {
                stringBuilder.Append(wordlist[random.Next(0, wordlist.Count - 1)] + " ");

            }
            ((FirstCourse)screen).TextBlockScreen.Text = stringBuilder.ToString();
        }
    }
}
