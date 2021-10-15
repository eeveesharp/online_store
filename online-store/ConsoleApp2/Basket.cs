using System;
using System.Collections.Generic;

namespace Online_Shop
{
    public class Basket
    {
        private readonly Timer _timer = new Timer();
        private int quantity;
        int id;
        Product product = new Product();

        public void AddProduct()
        {
            File.ReadProduct("products");

            while (true)
            {
                Console.Clear();
                int numberMenu;
                product.ShowProduct();
                Console.WriteLine("Would you like to add a product?");
                Console.WriteLine("1.Yes\n2.No");
                numberMenu = GetNumber(count: 2);

                if (numberMenu == 2)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Enter ID");
                    id = GetNumber(Storage.Products.Count);
                    Console.WriteLine("Enter quantity");
                    quantity = GetQuantityProduct(Storage.Products[id - 1].Quantity);

                    _timer.Start();

                    if (Storage.Basket is null)
                    {
                        Storage.Basket = new List<Product>();
                    }

                    if (Storage.HistoryBuy is null)
                    {
                        Storage.HistoryBuy = new List<Product>();
                    }

                    for (int i = 0; i < Storage.Products.Count; i++)
                    {
                        if (id == Storage.Products[i].ID)
                        {
                            int temp;
                            var productBasket = Storage.Products[i];
                            productBasket.Quantity -= quantity;
                            temp = productBasket.Quantity;
                            productBasket.Quantity = quantity;
                            Storage.Basket.Add(productBasket);
                            productBasket.Quantity = temp;
                        }
                    }
                }
            }
        }

        public static void DeleteProductsByTimer()
        {
            Storage.Basket = new List<Product>();
        }

        private int GetNumber(int count)
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number > count || number <= 0)
            {
                Console.WriteLine("Error.Id is missing");
            }

            return number;
        }

        public void ShowBasket()
        {
            for (int i = 0; i < Storage.Basket.Count; i++)
            {
                Console.WriteLine($"ID:{Storage.Basket[i].ID}\n NAME:{Storage.Basket[i].Name}\n PRICE:{Storage.Basket[i].Price}\n QUANTITY:{Storage.Basket[i].Quantity}\n DESCRIPTION:\n{Storage.Basket[i].Description}\n");
                product.Line();
            }
        }

        public void BuyProduct()
        {
            int menu;

            if (Storage.Basket.Count == 0)
            {
                Console.WriteLine("The basket is empty");
            }
            else
            {
                ShowBasket();
                Console.WriteLine("Do you want to buy these products ?");
                Console.WriteLine("1.Yes\n2.No");
                menu = GetNumber(count: 2);

                switch (menu)
                {
                    case 1:
                        {
                            File.Write(Storage.Products, "products");
                            for (int i = 0; i < Storage.Basket.Count; i++)
                            {
                                var productBasket = Storage.Basket[i];
                                productBasket.Date = DateTime.Now;
                                Storage.HistoryBuy.Add(productBasket);
                                File.Write(Storage.HistoryBuy, Storage.CurrentUser.Login);
                            }

                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public void ShowHistoryBuy()
        {
            File.ReadHistoryBuy(Storage.CurrentUser.Login);

            for (int i = 0; i < Storage.HistoryBuy.Count; i++)
            {
                Console.WriteLine($"ID:{Storage.HistoryBuy[i].ID}\n NAME:{Storage.HistoryBuy[i].Name}\n PRICE:{Storage.HistoryBuy[i].Price}\n QUANTITY:{Storage.HistoryBuy[i].Quantity}\n DESCRIPTION:\n{Storage.HistoryBuy[i].Description}\n Date:\n{Storage.HistoryBuy[i].Date}");
                product.Line();
            }
        }

        private int GetQuantityProduct(int number)
        {
            int quantity;

            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity > number || number <= 0)
            {
                if (number == 0)
                {
                    Console.WriteLine("Not on sale");
                }
                else
                {
                    Console.WriteLine("Erorr.Enter the correct value");
                }
            }

            return quantity;
        }

        public void FindProduct()
        {
            Console.Clear();
            string nameProduct;
            int count = 0;
            int numberMenu;
            Console.WriteLine("Enter product");
            nameProduct = Console.ReadLine();         

            for (int i = 0; i < Storage.Products.Count; i++)
            {
                if (nameProduct == Storage.Products[i].Name)
                {
                    Console.WriteLine($"ID:{Storage.Products[i].ID}\n NAME:{Storage.Products[i].Name}\n PRICE:{Storage.Products[i].Price}\n QUANTITY:{Storage.Products[i].Quantity}\n DESCRIPTION:\n{Storage.Products[i].Description}");
                    id = Storage.Products[i].ID;
                    product.Line();
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                Console.WriteLine("Would you like to add this product?");
                Console.WriteLine("1.Yes\n2.No");
                numberMenu = GetNumber(count: 2);

                if (numberMenu == 2)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Enter quantity");
                    quantity = GetQuantityProduct(Storage.Products[id - 1].Quantity);

                    _timer.Start();

                    if (Storage.Basket is null)
                    {
                        Storage.Basket = new List<Product>();
                    }

                    if (Storage.HistoryBuy is null)
                    {
                        Storage.HistoryBuy = new List<Product>();
                    }

                    int temp;
                    var productBasket = Storage.Products[id - 1];
                    productBasket.Quantity -= quantity;
                    temp = productBasket.Quantity;
                    productBasket.Quantity = quantity;
                    Storage.Basket.Add(productBasket);
                    productBasket.Quantity = temp;
                }
            }
        }
    }
}
