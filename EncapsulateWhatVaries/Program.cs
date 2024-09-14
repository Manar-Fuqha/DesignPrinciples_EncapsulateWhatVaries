using System;
namespace EncapsulateWhatVaries
{

     class Program
    {

        static void Main(string[] args)
        {
            Pizza pizza = Pizza.Order(PizzaConstants.CheesePizza);
            Console.WriteLine(pizza);
        }
    }


    class Pizza
    {
        public virtual string Title => $"{nameof(Pizza)}";
        public virtual decimal Price => 10m;

        public static Pizza Create(string type)
        {
            Pizza pizza;
            if(type.Equals(PizzaConstants.CheesePizza))
            {
                pizza = new Cheese();
            }
            else if (type.Equals(PizzaConstants.ChickenPizza))
            {
                    pizza = new Chicken();
            }
            else
            {
                pizza = new Vegeterian();
            }

            return pizza;
        }


        public static Pizza Order (string type)
        {
            Pizza pizza;

            pizza = Create(type);

            Prepare();
            Cook();
            Cut();

            return pizza;
        }


        public static void Prepare()
        {
            Console.Write("preparing...");
            Thread.Sleep(500);
            Console.WriteLine(" completed");
        }

        public static void Cook()
        {
            Console.Write("cooking...");
            Thread.Sleep(500);
            Console.WriteLine(" completed");
        }

        public static void Cut()
        {
            Console.Write("cutting and boxing...");
            Thread.Sleep(500);
            Console.WriteLine(" completed");
        }

        public override string ToString()
        {
            return $"\n{Title}" +
                   $"\n\tPrice: {Price.ToString("C")}";
        }
    }

    class Cheese : Pizza
    {
        public override string Title => $"{nameof(Cheese)} {base.Title}";
        public override decimal Price => base.Price + 3m;
    }

    class Chicken : Pizza
    {
        public override string Title => $"{nameof(Chicken)} {base.Title}";
        public override decimal Price => base.Price +7m;
    }

    class Vegeterian : Pizza
    {
        public override string Title => $"{nameof(Vegeterian)} {base.Title}";
        public override decimal Price => base.Price + 5m;

    }


}
