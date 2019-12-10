using System;
using System.Globalization;

namespace OOPS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region VirtualOverride 
                DClass d = new DClass();

                d.GetInfo();

                BClass b = new BClass();

                b.GetInfo();

                BClass bd = new DClass();

                bd.GetInfo();

                //Compile time Error CS0266  Cannot implicitly convert type 'OOPS.BClass' to 'OOPS.DClass'.An explicit conversion exists (are you missing a cast?)
                //DClass db = new BClass();

                Console.WriteLine("\nPress Enter Key to Exit..");

                Console.ReadLine();
                #endregion VirtualOverride

                #region RunTimePolymorphism
                Shape[] s = new Shape[3];
                /* Polymorphic Objects, creating Array with Different types of Objects */
                s[0] = new Circle(); 
                s[1] = new Rectangle(); 
                s[2] = new Triangle();
                for (int i = 0; i < 3; i++) 
                    s[i].Draw();
                #endregion RunTimePolymorphism

                #region NumberFormatInfo
                //// Gets a NumberFormatInfo associated with the en-US culture.
                //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

                //// Displays a negative value with the default number of decimal digits (2).
                //Int64 myInt = -1234;
                //Console.WriteLine(myInt.ToString("N", nfi));

                //// Displays the same value with four decimal digits.
                //nfi.NumberDecimalDigits = 4;
                //Console.WriteLine(myInt.ToString("N", nfi));

                //decimal d = 1M;
                //nfi.NumberDecimalDigits = 4;
                //Console.WriteLine(d + 0.00001M);
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                while (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                    e = e.InnerException;
                }
            }
        }
    }

    // Base Class
    public class BClass
    {
        public virtual void GetInfo()
        {
            Console.WriteLine("Base class called");
        }
    }

    // Derived Class
    public class DClass : BClass
    {
        public override void GetInfo()
        {
            Console.WriteLine("Derived class called");
        }
    }

    class Shape { public virtual void Draw() { } }
    class Rectangle : Shape { public override void Draw() { Console.WriteLine("Rectangle Drawn "); } }
    class Circle : Shape { public override void Draw() { Console.WriteLine("Circle Drawn "); } }
    class Triangle : Shape { public override void Draw() { Console.WriteLine("Triangle Drawn "); } }
}
