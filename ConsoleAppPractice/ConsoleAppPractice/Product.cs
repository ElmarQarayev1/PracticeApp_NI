using System;
namespace ConsoleAppPractice
{
	public class Product
	{
        public Product()
        {
            DefaultNo++;
            No = DefaultNo;
        }

        public Product(string ad, double satisQiymeti, double AlisQiymeti, DateTime expireDate) : this()
        {
            Name = ad;
            SalePrice = satisQiymeti;
            CostPrice = AlisQiymeti;
            ExpireDate = expireDate;
        }

        static int DefaultNo =0;
        public readonly int No;
        public string Name;
        public double SalePrice;
        public double CostPrice;
        public DateTime ExpireDate;

        public override string ToString()
        {
            return $"No: {No} - ad: {Name} - qiymet: {SalePrice} - Son istifade tarixi: {ExpireDate.ToString("dd.MM.yyyy")}";
        }
    }
}

