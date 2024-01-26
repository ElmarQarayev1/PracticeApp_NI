using System;
namespace ConsoleAppPractice
{
	public interface IMarket
	{
        Product[] Products { get; }
        void AddProduct(Product product);
        void RemoveProductByNo(int no);
        void Sell(int no, int count = 1);

    }
}

