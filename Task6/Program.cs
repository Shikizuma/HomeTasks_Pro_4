using System.Text.RegularExpressions;

namespace Task6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string loginPattern = @"^[A-Za-z0-9]{4,20}$";
            Console.WriteLine("Введить ваш логін");
            string login = Console.ReadLine();

			if (Regex.IsMatch(login, loginPattern))
			{
                Console.WriteLine("Реєстрація пройшла успішно");
            }
			else
			{
				Console.WriteLine("Реєстрація не пройшла");
			}
		}
	}
}