using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.App
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int num1, int num2)
        {
            //if (num1 == 0 || num2 == 0)
            //{
            //    return 0;
            //}
            return num1 + num2;
        }

        public int Multip(int num1,int num2)
        {
            if(num1 == 0)
            {
                throw new Exception("First number does not zero.");
            }
            return (num1 * num2);
        }
    }
}
