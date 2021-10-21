using System;
using System.Collections.Generic;

namespace Online_Shop
{
    public class Basket
    {
        private readonly Timer _timer;

        private int _quantity;

        private int _id;

        private readonly Product _product;

        private readonly File _file;

        private List<int> _arrayIdFoundProduct = new List<int>();

        public Basket()
        {
            _timer = new Timer();

            _product = new Product();

            _file = new File();
        }

        public void ShowBasket()
        {
            for (int i = 0; i < Storage.Basket.Count; i++)
            {
                Console.WriteLine($"ID:{Storage.Basket[i].ID}\n " +
                    $"NAME:{Storage.Basket[i].Name}\n " +
                    $"PRICE:{Storage.Basket[i].Price}\n " +
                    $"QUANTITY:{Storage.Basket[i].Quantity}\n " +
                    $"DESCRIPTION:\n{Storage.Basket[i].Description}\n");

                _product.Line();
            }
        }

        public void BuyProductInBasket()
        {
            if (Storage.Basket is null)
            {
                Storage.Basket = new List<Product>();
            }

            if (Storage.Basket.Count == 0)
            {
                Console.WriteLine("The basket is empty");
            }
            else
            {               
                GetMenuBuyProduct();
            }
        }

        private void GetMenuBuyProduct()
        {
            ShowBasket();

            Console.WriteLine("Do you want to buy these products ?");

            Console.WriteLine("1.Yes\n2.No");

            int menu = GetNumber(range: 2);

            switch (menu)
            {
                case 1:
                    {
                        BuyProduct();
                        break;
                    }
                case 2:
                    {
                         _file.ReadProduct("products");

                        return;
                    }
                default:
                    break;
            }
        }

        public void GetMenuAddProductInBasket()
        {
            while (true)
            {
                _product.ShowProduct();

                Console.WriteLine("Would you like to add a product in basket?"); // в метод 

                Console.WriteLine("1.Yes\n2.No");

                int menu = GetNumber(range: 2);

                switch (menu)
                {
                    case 1:
                        {
                            AddProductInBasket();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            return;
                        }
                    default:
                        break;
                }
            }
        }

        private void BuyProduct()
        {
            _file.Write(Storage.Products, "products");

            for (int i = 0; i < Storage.Basket.Count; i++)
            {
                var productBasket = Storage.Basket[i];

                productBasket.Date = DateTime.Now;

                Storage.HistoryBuy.Add(productBasket);

                _file.Write(Storage.HistoryBuy,
                    Storage.CurrentUser.Login);
            }

            Storage.Basket = new List<Product>();

            Console.Clear();
        }

        public void ShowHistoryBuy()
        {
            _file.ReadHistoryBuy(Storage.CurrentUser.Login);

            for (int i = 0; i < Storage.HistoryBuy.Count; i++)
            {
                Console.WriteLine($"ID:{Storage.HistoryBuy[i].ID}\n " +
                    $"NAME:{Storage.HistoryBuy[i].Name}\n " +
                    $"PRICE:{Storage.HistoryBuy[i].Price}\n " +
                    $"QUANTITY:{Storage.HistoryBuy[i].Quantity}\n " +
                    $"DESCRIPTION:\n{Storage.HistoryBuy[i].Description}\n " +
                    $"Date:\n{Storage.HistoryBuy[i].Date}");

                _product.Line();
            }
        }

        private int GetQuantityProduct(int number)
        {
            while (!int.TryParse(Console.ReadLine(), out _quantity)
                || _quantity > number
                || _quantity <= 0)
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

            return _quantity;
        }

        private void AddProductInBasket()
        {
            Console.WriteLine("Enter ID");

            _id = GetId();

            Console.WriteLine("Enter quantity");

            _quantity = GetQuantityProduct(Storage.Products[_id].Quantity);

            _timer.Start();

            if (Storage.Basket is null)
            {
                Storage.Basket = new List<Product>();
            }

            if (Storage.HistoryBuy is null)
            {
                Storage.HistoryBuy = new List<Product>();
            }

            Storage.Basket.Add(new Product(Storage.Products[_id].ID,
                Storage.Products[_id].Name,
                Storage.Products[_id].Price, _quantity,
                Storage.Products[_id].Description));

            Storage.Products[_id].Quantity -= _quantity;
        }

        private void AddFoundProductInBasket()
        {
            do
            {
                Console.WriteLine("Enter ID");

                _id = GetId();

            } while (!IsGetIdFoundProduct());

            Console.WriteLine("Enter quantity");

            _quantity = GetQuantityProduct(Storage.Products[_id].Quantity);

            _timer.Start();

            if (Storage.Basket is null)
            {
                Storage.Basket = new List<Product>();
            }

            if (Storage.HistoryBuy is null)
            {
                Storage.HistoryBuy = new List<Product>();
            }

            Storage.Basket.Add(new Product(Storage.Products[_id].ID,
                Storage.Products[_id].Name,
                Storage.Products[_id].Price, _quantity,
                Storage.Products[_id].Description));

            Storage.Products[_id].Quantity -= _quantity;
        }

        public void CheckFoundProduct()
        {
            if (!IsSearchProduct())
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                GetFoundProductInBasket();
            }
        }

        private void GetFoundProductInBasket()
        {
            int menuNumber;

            Console.WriteLine("Would you like to add a product?");

            Console.WriteLine("1.Yes\n2.No");

            menuNumber = GetNumber(range: 2);

            switch (menuNumber)
            {
                case 1:
                    {
                        AddFoundProductInBasket();

                        Console.Clear();

                        break;
                    }
                case 2:
                    {
                        Console.Clear();

                        return;
                    }
                default:
                    break;
            }
        }

        private bool IsSearchProduct()
        {
            bool isSearchProduct = false;

            string nameProduct;

            Console.WriteLine("Enter product");

            nameProduct = Console.ReadLine();

            for (int i = 0; i < Storage.Products.Count; i++) 
            {
                string name = Storage.Products[i].Name;

                if (name.ToLower().Contains(nameProduct.ToLower()))
                {
                    Console.WriteLine($"ID:{Storage.Products[i].ID}\n " +
                        $"NAME:{Storage.Products[i].Name}\n " +
                        $"PRICE:{Storage.Products[i].Price}\n " +
                        $"QUANTITY:{Storage.Products[i].Quantity}\n " +
                        $"DESCRIPTION:\n{Storage.Products[i].Description}");

                    _id = Storage.Products[i].ID;

                    _product.Line();

                    _arrayIdFoundProduct.Add(_id);

                    isSearchProduct = true;
                }
            }

            return isSearchProduct;
        }

        public static void DeleteProductsByTimer()
        {
            Storage.Basket = new List<Product>();
        }

        private int GetNumber(int range)
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number)
                || number > range
                || number <= 0)
            {
                Console.WriteLine("Error.Id");
            }

            return number;
        }

        private int GetId()
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number)
                || number > Storage.Products.Count
                || number <= 0
                || Storage.Products[number - 1].Quantity == 0)
            {
                Console.WriteLine("Error.Id is missing or product not on sale");
            }

            return number - 1;
        }

        private bool IsGetIdFoundProduct()
        {
            bool isGetIdFoundProduct = false;

            for (int i = 0; i <_arrayIdFoundProduct.Count ; i++)
            {
                for (int j = 0; j < _arrayIdFoundProduct.Count; j++)
                {
                    if (_arrayIdFoundProduct[i] == _id + 1)
                    {
                        isGetIdFoundProduct = true;
                    }
                }
            }

            return isGetIdFoundProduct;
        }
    }
}
