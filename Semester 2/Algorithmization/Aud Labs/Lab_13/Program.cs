using Casual;
using System.Security;
using System.Text.RegularExpressions;

internal class Program
{
    static List<Supply>  getProviderSupplies(int providerId, List<Supply> supplies)
    {
        var finalSupplies = new List<Supply>(
            from supply in supplies
            where supply.ProviderId == providerId
            select supply
            );
        return finalSupplies;
    }

    static Dictionary<int, int> getProductsAmount(List<Supply> supplies, int providerId)
    {
        Dictionary<int, int> products = new Dictionary<int, int>();
        products[0] = providerId;
        foreach (var supply in supplies)
        {
            if (!products.TryAdd(supply.ProductId, supply.ProductAmount))
                products[supply.ProductId] += supply.ProductAmount;
        }
        return products;
    }

    static Product getProductById(List<Product> products, int productId)
    {
        return new List<Product>(
            from product in products
            where product.Id == productId
            select product
            )[0];
    }

    static Provider getProviderById(List<Provider> providers, int providerId)
    {
        return new List<Provider>(
            from provider in providers
            where provider.Id == providerId
            select provider
            )[0];
    }
    private static void Main(string[] args)
    {
        var products = new List<Product>();
        var providers = new List<Provider>();
        var supplies = new List<Supply>();

        for (int i = 1; i < 5; i++)
        {
            products.Add(new Product(
                String.Format("product {0}", i), i)
                );
            providers.Add(new Provider(
                String.Format("Provider {0}", i)
                ));
        }

        for (int i = 1; i < 5; i++)
        {
            for (int j = i; j < 5; j++)
            {
                supplies.Add(new Supply(i, j, i + j, new DateTime(2023, 5, i + j)));
            }
        }

        var supplyDate = new DateTime(2023, 5, 7);

        var filteredByDateProducts = from supply in supplies
                                     where supply.Date == supplyDate
                                     from product in products
                                     where product.Id == supply.ProductId
                                     select product;

        var itemToProvider = from provider in providers
                             from supply in supplies
                             where supply.ProviderId == provider.Id
                             group provider by supply.ProductId;
        

        var providerSupplyInformaition = from provider in providers
                                         let pair = getProductsAmount(
                                             getProviderSupplies(provider.Id, supplies),
                                             provider.Id
                                             )
                                         group pair by pair[0];



        Console.WriteLine("Фильтровка по дате");
        foreach(var item in filteredByDateProducts)
        {
            Console.WriteLine(item.Name + " ");
        }

        Console.WriteLine();

        Console.WriteLine("Фильтровка по поставщикам");
        foreach (var providerByProduct in itemToProvider)
        {
            Console.Write(getProductById(products, providerByProduct.Key).Name + ": ");
            foreach (var provider in providerByProduct)
            {
                Console.Write(provider.Name + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Фильтровка вида поставщик: купленный_продукт количество");
        foreach (var pair in providerSupplyInformaition)
        {
            Console.WriteLine(getProviderById(providers, pair.Key).Name + ":");
            foreach (var item in pair)
            { 
                foreach (int productId in item.Keys)
                {
                    if (productId == 0)
                        continue;
                    Console.WriteLine(getProductById(products, productId).Name + " amount " + item[productId]);
                }
                Console.WriteLine();
            }
        }
    }
}
