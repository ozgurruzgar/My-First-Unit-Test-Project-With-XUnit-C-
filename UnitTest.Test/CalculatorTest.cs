using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnitTest.App;
using Xunit;

namespace UnitTest.Test
{
    public class CalculatorTest
    {
        public Calculator calculator { get; set; }
        public Mock<ICalculatorService> myMock { get; set; }
        public CalculatorTest()
        {
            myMock = new Mock<ICalculatorService>();
            calculator =  new Calculator(myMock.Object);
        }

        //[Fact]
        //public void AddTest()
        //{
        //    //Arrange Evresi
        //    int num1 = 5;
        //    int num2 = 20;
        //    //var calculator = new Calculator();

        //    //Act Evresi
        //    var total = calculator.Add(num1, num2);

        //    //Assert Evresi
        //    Assert.Equal<int>(25, total);

        //    //Assert.Contains("Özgür", "Özgür Rüzgar"); //Beklediğmiz ifadenin gerçek ifade de geçip geçmediğini kontrol ediyor.
        //}


        [Theory] //Parametre alan metotlarda kullanılır.
        [InlineData(2, 5, 7)] //bu ifade ile parametre değerlerimizi vermiş oluyoruz.
        [InlineData(10, 2, 12)]
        public void Add_simpleValues_returnTotalValue(int num1, int num2, int expectedTotal)
        {
            //var calculator = new Calculator();

            myMock.Setup(x => x.Add(num1,num2)).Returns(expectedTotal);

            var actualData = calculator.Add(num1, num2);

            Assert.Equal(expectedTotal, actualData);

            myMock.Verify(x => x.Add(num1, num2), Times.Once);
        }

        [Theory] //Parametre alan metotlarda kullanılır.
        [InlineData(0,2,0)] //bu ifade ile parametre değerlerimizi vermiş oluyoruz.
        [InlineData(10, 0, 0)]
        public void Add_zeroValues_returnZeroValue(int num1,int num2,int expectedTotal)
        {
            //var calculator = new Calculator();

            var actualData = calculator.Add(num1, num2);

            Assert.Equal(expectedTotal, actualData);
        }

        [Theory]
        [InlineData(3,5)]
        public void Multip_zeroValue_ReturnException(int num1,int num2)
        {
            myMock.Setup(x => x.Multip(num1, num2)).Throws(new Exception("First number does not zero."));
            // Assert.Equal(15, calculator.Multip(3, 5));

          Exception exception = Assert.Throws<Exception>(() =>
            {
                calculator.Multip(num1, num2);
            });

            Assert.Equal("First number does not zero.",exception.Message);
        }
        [Theory]
        [InlineData(3, 5,15)]
        public void Multip_SimpleValues_ReturnMultipValue(int num1, int num2,int expectedValue)
        {
            int actualMultip=0;
            myMock.Setup(x => x.Multip(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((x, y) => actualMultip = x * y);

            calculator.Multip(num1, num2);

            Assert.Equal(expectedValue, actualMultip);

            calculator.Multip(5, 20);

            Assert.Equal(100, actualMultip);
        }
    }
}
