
using ConsoleAppPractice;
using ConsoleAppPractice.Exceptions;

Market market = new Market();
market.AlcoholPercentLimit = 34;
string secim;
do
{
    secim = SecimEt();

    switch (secim)
    {
        case "1":
            AddProduct();
            break;
        case "2":
            RemoveProduct();
            break;
        case "3":
            ShowProducts();
            break;
        case "4":
            Uptade();
            break;
        case "5":
            Sell();
            break;
        case "6":
            Console.WriteLine(market.AvgAlcoholPercent);
            ShowProfits();
            break;
        default:
            break;
    }

} while (secim != "0");

string SecimEt()
{
    ShowMenu();
    Console.WriteLine("Emeliyyat secin: ");
    return Console.ReadLine();
}
void ShowMenu()
{
    Console.WriteLine("1.Mehsul elave et");
    Console.WriteLine("2.Mehsul sil");
    Console.WriteLine("3.Mehsullara bax");
    Console.WriteLine("4.Mehsulu tezele");
    Console.WriteLine("5.Mehsul sat");
    Console.WriteLine("6.Ortalama alkaqol faizine bax");
    Console.WriteLine("0.Programi bitir");
}

void ShowProfits()
{
    Console.WriteLine("butun mehsul geliri:");
    Console.WriteLine(market.GetAllProfit()); 
    Console.WriteLine("alkaqoldan gelen gelir:");
    Console.WriteLine(market.GetAlcoholProfit()); 
    Console.WriteLine("alkoqolsuz gelir:");
    Console.WriteLine(market.GetNonAlcoholProfit()); 

}

void AddProduct()
{
    Console.WriteLine("Ad: ");
    string name;
    do
    {

         name = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(name));
   

    Console.WriteLine("ilkin qiymeti: ");
    string StrCostPrice = Console.ReadLine();
    double costPrice = Convert.ToDouble(StrCostPrice);

    Console.WriteLine("Satis qiymeti: ");
    string StrSalaPrice = Console.ReadLine();
    double salePrice = Convert.ToDouble(StrSalaPrice);


    Console.WriteLine("son istifade muddeti : ");
    string StrExpireDate = Console.ReadLine();
    DateTime expireDate = Convert.ToDateTime(StrExpireDate);

checkIsDrink:
    Console.WriteLine("Icki mehsuludurmu? y/n");
    string StrIsDrink = Console.ReadLine();

    Product product;
    string StrAlcoholPercent = null;
    if (StrIsDrink == "y")
    {
        Console.WriteLine("Alkoqol faizi: ");
        StrAlcoholPercent = Console.ReadLine();
        double alcoholPercent = Convert.ToDouble(StrAlcoholPercent);
        product = new DrinkProduct(name, salePrice, costPrice, expireDate, alcoholPercent);
    }
    else if (StrIsDrink == "n")
    {
        product = new Product(name, salePrice, costPrice, expireDate);
    }
    else
        goto checkIsDrink;

    market.AddProduct(product);
}

void ShowProducts()
{
    Console.WriteLine("1.Butun mehsullar");
    Console.WriteLine("2.Alkaqollu ickiler");
    Console.WriteLine("3.Alkaqolsuz ickiler");
    Console.WriteLine("Secim:");
    string secimm = Console.ReadLine();

    switch (secimm)
    {
        case "1":
            for (int i = 0; i < market.Products.Length; i++)
               Console.WriteLine(market.Products[i]);
            break;
        case "2":
            var alcoholProducts = market.GetAllAlcoholDrinks();
            for (int i = 0; i < alcoholProducts.Length; i++)
                Console.WriteLine(alcoholProducts[i]);
            break;
        case "3":
            var AlkaqolsuzIckiler = market.GetAllNonAlcoholDrinks();
            for (int i = 0; i < AlkaqolsuzIckiler.Length; i++)
                Console.WriteLine(AlkaqolsuzIckiler[i]);
            break;
        default:
            Console.WriteLine("Secim yanlisdir!");
            break;
    }
}
void Uptade()
{
    for (int i = 0; i < market.Products.Length; i++)
        Console.WriteLine(market.Products[i]);
    string noStr;
    int no;
    do
    {

        Console.WriteLine("Melsul nomresini qeyd edin:");
        noStr = Console.ReadLine();
    } while (!int.TryParse(noStr,out no));
    string name;
    do
    {
        Console.WriteLine("mehsulun yeni adini qeyd edin: ");
         name = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(name));
    try
    {
        market.Uptade(no,name);
    }
    catch (ProductNotFoundException)
    {
        Console.WriteLine($"qeyd etdiyiniz nomreli mehsul yoxdur");
    }
}
void RemoveProduct()
{
    for (int i = 0; i < market.Products.Length; i++)
        Console.WriteLine(market.Products[i]);
    Console.WriteLine("Melsul nomresini qeyd edin:");
    string noStr = Console.ReadLine();
    int no = Convert.ToInt32(noStr);

    try
    {
        market.RemoveProductByNo(no);
    }
    catch (ProductNotFoundException)
    {
        Console.WriteLine($"qeyd etdiyiniz nomreli mehsul yoxdur");
    }
    catch (ProductExpireDateException)
    {
        Console.WriteLine($"Mehsulun son istifade muddetinin bitmesine 1 ilden artiq var");
    }
    catch
    {
        Console.WriteLine("bir xeta bas verdi");
    }

}
void Sell()
{
    for (int i = 0; i < market.Products.Length; i++)
        Console.WriteLine(market.Products[i]);
    Console.WriteLine("satmag istediyiniz mehsulun indexini qeyd edin:");
    string noStr = Console.ReadLine();
    int no = Convert.ToInt32(noStr);

    try
    {
        market.RemoveProductByNo(no);
    }
    catch (ProductNotFoundException)
    {
        Console.WriteLine($"qeyd etdiyiniz nomreli mehsul yoxdur");
    }
    string noS;
    int count;
    do
    {

        Console.WriteLine("Countunu qeyd edin:");
        noS = Console.ReadLine();
    } while (int.TryParse(noS, out count));

    market.Sell(no, count);

}
