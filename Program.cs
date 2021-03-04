using System;
using System.Globalization;

namespace Order.Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date: ");
            DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());
            Client newClient = new Client(clientName, clientEmail, clientBirthDate);


            Console.WriteLine("Enter the order data: ");
            Console.Write("Status: ");
            OrderStatus status;
            string orderAux = Console.ReadLine();
            Enum.TryParse(orderAux, out status);
            DateTime orderMoment = DateTime.Now;
            Order newOrder = new Order(orderMoment, status);
            newOrder.AddClient(newClient);


            Console.Write("How many items to this order? ");
            int controlExec = int.Parse(Console.ReadLine());
            Console.WriteLine();


            for (int i = 1; i <= controlExec; i++)
            {
                Console.WriteLine("Enter {0} item data:", i);
                Console.Write("Product Name: ");
                string itemName = Console.ReadLine();
                Console.Write("Product price: ");
                double itemPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int itemQuantity = int.Parse(Console.ReadLine());

                Product newProduct = new Product(itemName, itemPrice);
                OrderItem newItem = new OrderItem(itemQuantity, itemPrice);
                newOrder.AddItem(newItem);
                newItem.AddProduct(newProduct);
                Console.WriteLine();

                if (i == controlExec)
                {
                    Console.Write(newOrder);
                    Console.Write(newOrder.Total(newItem).ToString("F2", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
