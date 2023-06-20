using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.App
{
    public class Calculator
    {
        private ICalculatorService _calculatorService;
        public Calculator(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        public int Add(int num1, int num2)
        {
            return _calculatorService.Add(num1, num2);
        }        
        public int Multip(int num1, int num2)
        {
            return _calculatorService.Multip(num1, num2);
        }
    }
}
