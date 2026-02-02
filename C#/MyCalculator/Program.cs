using System;

namespace myCalculator
{
    class Calculator

    {

        public static void Main(string[] args)
        {
            bool continueCalculation = true;
            while (continueCalculation)
            {
                Console.WriteLine("Enter first number:");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter operator (+, -, *, /):");
                string op = Console.ReadLine() ?? "";

                Console.WriteLine("Enter second number:");
                int num2 = Convert.ToInt32(Console.ReadLine());

                int result = 0;

                if (op == "+")
                {
                    result = num1 + num2;
                }
                else if (op == "-")
                {
                    result = num1 - num2;
                }
                else if (op == "*")
                {
                    result = num1 * num2;
                }
                else if (op == "/")
                {
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        continue;
                    }
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Invalid operator");
                    continue;
                }

                Console.WriteLine($"Result: {result}");


                Console.WriteLine("Do you want to perform another calculation? (yes/no)");
                string answer = Console.ReadLine() ?? "";
                if (answer.ToLower() != "yes")
                {
                    continueCalculation = false;
                    Console.WriteLine("Exiting the calculator. Goodbye!");
                }
            }
        }
    }
    
}
