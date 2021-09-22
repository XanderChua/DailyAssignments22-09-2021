using System;

namespace DelegateCalculator
{
    public delegate void EventHandler(int add, int min, int x, int div);
    class Calculator //publisher
    {
        public event EventHandler send;
        int a;
        int b;
        int add;
        int min;
        int x; 
        int div;
        public void GetInput(int a, int b)
        {
            this.a = a;
            this.b = b;
            delegateAdd();
            delegateMin();
            delegateX();
            delegateDiv();
            Notify();
        }
        public void delegateAdd()
        {
            add = a + b;
        }
        public void delegateMin()
        {
            min = a - b;
        }
        public void delegateX()
        {
            x = a * b;
        }
        public void delegateDiv()
        {
            div = a / b;
        }
        private void Notify()
        {
            if(send != null)
            {
                send(add, min, x, div);
            }
        }
    }
    class DelegateCalculator //subscriber
    {     
        static void Main(string[] args)
        {
            Console.WriteLine("--Delegate Calculator--");
            print();
        }
        public static void print()
        {
            Console.WriteLine("Enter 1st number:");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number:");
            int b = Int32.Parse(Console.ReadLine());
            Calculator cal = new Calculator();
            cal.send += Calculator_performAddEvent;
            cal.GetInput(a, b);
            Console.ReadLine();
        }
        private static void Calculator_performAddEvent(int add, int min, int x, int div)
        {
            Console.WriteLine("Addition: " + add);
            Console.WriteLine("Subtraction: " + min);
            Console.WriteLine("Multiplication: " + x);
            Console.WriteLine("Division: " + div);
        }
    }
}
