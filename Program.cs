using System;

namespace Lab15_Events
{
    class Program
    {
        // delegate
        delegate void MyDelegate();
        delegate int MyDelegate02(int x);
        //create event (empty at the moment)
        static event MyDelegate MyEvent;
        static event MyDelegate02 MyEvent02;
        static void Main(string[] args)
        {
            // Related to Child class
            var James = new Child("James");
            James.Grow();
            James.Grow();
            James.Grow();

            //related to program class
            //add method to event
            MyEvent += Method01;
            MyEvent += Method02;
            MyEvent -= Method02;
            MyEvent += Method02;
            MyEvent += Method02;
            MyEvent02 += Method03;

            //fire event
            MyEvent();
            MyEvent02(4);
        }
        static void Method01()
        {
            Console.WriteLine("Running Method01");
        }
        static void Method02()
        {
            Console.WriteLine("Running Method02");
        }
        static int Method03(int x)
        {
            Console.WriteLine(x * x);
            return x * x;
        }
    }
           


    class Child
    {
        //Trivial event annual birthday
        delegate void BirthdayDelegate();
        // Event call the method
        event BirthdayDelegate HaveABirthday;
        public string Name { get; set; }
        public int Age { get; set; }

        public void HaveAParty()
        {
            //This refers to the instance
            this.Age++;
            Console.WriteLine("Hey celebrating another year!" + $"Age is now {this.Age}");
        }

        public Child(string Name)
        {
            this.Name = Name;
            this.Age = 0;
            HaveABirthday += HaveAParty;    //placeholder
        }

        public void Grow()
        {
            HaveABirthday();    // call the event
        }
    }
}
