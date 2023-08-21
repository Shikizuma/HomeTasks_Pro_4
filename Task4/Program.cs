using System.Globalization;

namespace Task4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] items = { "Ноутбук", "Мишка", "Клавіатура", "Монітор" };
			double[] prices = { 1200.00, 25.50, 30.00, 350.00 };
			DateTime purchaseDate = DateTime.Now;

			CreateReceipt("user_receipt.txt", items, prices, purchaseDate, CultureInfo.CurrentCulture);

			CreateReceipt("en_us_receipt.txt", items, prices, purchaseDate, new CultureInfo("en-US"));

			Console.WriteLine("Чеки створені та записані.");
		}

		static void CreateReceipt(string fileName, string[] items, double[] prices, DateTime purchaseDate, CultureInfo cultureInfo)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				writer.WriteLine($"Чек покупки ({cultureInfo.DisplayName}):");
				writer.WriteLine("------------------------------");

				for (int i = 0; i < items.Length; i++)
				{
					string formattedPrice = prices[i].ToString("C", cultureInfo); 
					writer.WriteLine($"{items[i]} - {formattedPrice}");
				}

				string formattedDate = purchaseDate.ToString("D", cultureInfo); 
				writer.WriteLine($"Дата покупки: {formattedDate}");
			}
		}
	}
}