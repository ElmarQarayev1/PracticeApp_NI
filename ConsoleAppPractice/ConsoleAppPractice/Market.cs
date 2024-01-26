using System;
using ConsoleAppPractice.Exceptions;

namespace ConsoleAppPractice
{
	public class Market:IMarket,IMarketReporter
	{
        private Product[] _products = new Product[0];
        public Product[] Products => _products;
        public int AlcoholPercentLimit;
        public double TotalSatis = 0;

        public double AvgAlcoholPercent
        {
            get
            {
                var spirtliIckiler = GetAllAlcoholDrinks();

                double totalPercent = 0;
                for (int i = 0; i < spirtliIckiler.Length; i++)
                    totalPercent += spirtliIckiler[i].AlcoholPercent;

                return spirtliIckiler.Length == 0 ? 0 : totalPercent / spirtliIckiler.Length;
            }
        }
        public void AddProduct(Product product)
        {
            if (product is DrinkProduct icki && icki.AlcoholPercent > this.AlcoholPercentLimit)
                return;

            Array.Resize(ref _products, _products.Length + 1);
            _products[_products.Length - 1] = product;
        }

        public double GetAlcoholProfit()
        {
            double Profits = 0;

            for (int i = 0; i <GetAllAlcoholDrinks().Length; i++)
            {
                Profits += GetAllAlcoholDrinks()[i].SalePrice - GetAllAlcoholDrinks()[i].CostPrice;

            }
            return Profits;
        }

        public double GetAllProfit()
        {
            double Profits = 0;
            for (int i = 0; i < GetAllDrinks().Length; i++)
            {
                Profits += GetAllDrinks()[i].SalePrice - GetAllDrinks()[i].CostPrice;
            }
            return Profits;
        }
        public double GetNonAlcoholProfit()
        {
            double Profits = 0;
            for (int i = 0; i < GetAllNonAlcoholDrinks().Length; i++)
            {
                Profits += GetAllNonAlcoholDrinks()[i].SalePrice - GetAllNonAlcoholDrinks()[i].CostPrice;

            }
            return Profits;
        }

        public void  Uptade(int no,string name)
        {
            var wantedProduct = FindByNo(no);
            if (wantedProduct == null) throw new ProductNotFoundException();
            var wantedIndex = FindIndexByNo(no);
            for (int i = 0; i < GetAllDrinks().Length; i++)
            {
                GetAllDrinks()[wantedIndex].Name = name;
            }   
        }
        public void RemoveProductByNo(int no)
        {
            var wantedProduct = FindByNo(no);
            if (wantedProduct == null) throw new ProductNotFoundException();

            if (wantedProduct.ExpireDate >= DateTime.Now.AddYears(1))
                throw new ProductExpireDateException();

            var wantedIndex = FindIndexByNo(no);
            for (int i = wantedIndex; i < _products.Length - 1; i++)
            {
                var temp = _products[i];
                _products[i] = _products[i + 1];
                _products[i + 1] = temp;
            }

            Array.Resize(ref _products, _products.Length - 1);

        }

        public Product FindByNo(int no)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].No == no)
                {
                    return _products[i];
                }
            }
            return null;
        }

        public int FindIndexByNo(int no)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].No == no)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Sell(int no, int count = 1)
        {
            var wantedProduct = FindByNo(no);
            if (wantedProduct == null) throw new ProductNotFoundException();
            var wantedIndex = FindIndexByNo(no);
            for (int i = 0; i < GetAllDrinks().Length; i++)
            {
                if (GetAllDrinks()[wantedIndex].No == no)
                {
                    TotalSatis += (GetAllDrinks()[i].SalePrice)*count;
                }
            }     
        }

        public DrinkProduct[] GetAllAlcoholDrinks()
        {
            DrinkProduct[] drinks = new DrinkProduct[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct drink && drink.AlcoholPercent > 0)
                {
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }

            return drinks;
        }

        public DrinkProduct[] GetAllDrinks()
        {
            DrinkProduct[] drinks = new DrinkProduct[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct drink)
                {
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }

            return drinks;
        }

        public DrinkProduct[] GetAllNonAlcoholDrinks()
        {
            DrinkProduct[] drinks = new DrinkProduct[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i] is DrinkProduct drink && drink.AlcoholPercent == 0)
                {
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }

            return drinks;
        }

       
    }
}

