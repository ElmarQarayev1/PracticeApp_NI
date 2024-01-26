using System;
namespace ConsoleAppPractice
{
	public class DrinkProduct:Product
	{
        public DrinkProduct()
        {

        }
        public DrinkProduct(string name, double salePrice, double costPrice, DateTime expireDate, double alcoholPercent) : base(name, salePrice, costPrice, expireDate)
        {
            this.AlcoholPercent = alcoholPercent;
        }
        public double AlcoholPercent;

        public override string ToString()
        {
            return base.ToString() + " - AlcoholPercent: " + AlcoholPercent;
        }
    }
}

