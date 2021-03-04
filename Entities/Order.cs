using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Order.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; private set; }
        private List<OrderItem> ItemList { get; set; } = new List<OrderItem>();
        private List<Client> ClientList { get; set; } = new List<Client>();


        public Order(DateTime moment, OrderStatus status)
        {
            Moment = moment;
            Status = status;
        }

        public void AddItem(OrderItem item)
        {
            ItemList.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            ItemList.Add(item);
        }
        public void AddClient(Client client)
        {
            ClientList.Add(client);
        }
        public void RemoveClient(Client client)
        {
            ClientList.Remove(client);
        }
        public Double Total(OrderItem item)
        {
            double sum = 0;
            foreach (OrderItem obj in ItemList)
            {
                sum += obj.Price * obj.Quantity;
            }
            return sum;
        }
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            foreach (Client client in ClientList)
            {
                sb.AppendLine(client.Name + " " + client.BirthDate.ToString("dd/MM/yyyy") + " - " + client.Email);
            }

            sb.AppendLine("Order items: ");

            foreach (OrderItem item in ItemList)
            {
                sb.Append(item.ProductList[0].Name + ", $");
                sb.Append(item.Price.ToString("F2", CultureInfo.InvariantCulture) + ", ");
                sb.Append("Quantity: " + item.Quantity + ", ");
                sb.AppendLine("Subtotal: $" +
                    item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("Total price: $");
            return sb.ToString();
        }
    }
}