using System;
namespace ConsoleAppPractice
{
	public interface IMarketReporter
	{
        double GetAllProfit();
        double GetAlcoholProfit();
        double GetNonAlcoholProfit();
    }
}

