using System;

namespace DelegateHCFandLCM
{
    public delegate void EventHandler(int HCF, int LCM);
    class Operation
    {
        public event EventHandler send;
        int a;
        int b;
        int hcf;
        int lcm;

        public void GetInput(int a, int b)
        {
            this.a = a;
            this.b = b;
            calculatehcf();
            calculatelcm();
            Notify();
        }
        private void calculatehcf()
        {
            for (int i = 1; i <= a || i <= b; ++i)
            {
                if (a % i == 0 && b % i == 0)
                {
                    hcf = i;
                }
            }
        }
        public void calculatelcm()
        {
            lcm = (a * b) / hcf; 
        }
        private void Notify()
        {
            if (send != null)
            {
                send(hcf, lcm);
            }
        }
    }
    class DelegateHCFandLCM
    {
        public static void print()
        {
            Console.WriteLine("Enter 1st input:");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd input:");
            int b = Int32.Parse(Console.ReadLine());
            Operation op = new Operation();
            op.send += Op_send;
            op.GetInput(a, b);
            Console.ReadLine();
        }

        private static void Op_send(int HCF, int LCM)
        {
            Console.WriteLine("HCF: "+ HCF);
            Console.WriteLine("LCM: "+LCM);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Find the Highest Common Factor and Lowest Common Multiple using Delegate Events");
            print();
        }
    }
}
