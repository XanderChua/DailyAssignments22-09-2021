using System;

namespace DelegateCountWord
{
    public delegate void EventHandler(string input);

    class CountWord //publisher
    {
        public event EventHandler send;
        string input;
        public void GetInput(string input)
        {
            this.input = input;
        }
    }
    class DelegateWordCount //subscriber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Delegate Count Words--");
            print();
        }
        
        public static void print()
        {
            Console.WriteLine("Input string:");
            string input = Console.ReadLine();
            CountWord cw = new CountWord();            
            cw.send += Cw_send;
            cw.GetInput(input);
            int wordCount = 1;
            foreach (char wordSpace in input)
            {
                if (wordSpace == ' ') 
                {
                    wordCount++;
                }
            }
            foreach (string word in input.Split(' '))
            {
                Cw_send(word);
            }
            Console.WriteLine("There are " + wordCount + " words.");
        }

        private static void Cw_send(string word)
        {
            Console.WriteLine(word);
        }
    }
}
