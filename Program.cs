namespace Practise05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            cake cake = order.order();
            string[] list = new string[4];
            list[0] = $"Заказ от {DateTime.Now}";
            list[1] = $"\tЗаказ: {cake.list}";
            list[2] = $"\tЦена: {cake.totalCost}";
            list[3] = "";
            File.AppendAllLines("D:\\Code\\C#\\ConsoleApp1\\Practise05\\Orders.txt", list);
        }
    }
}