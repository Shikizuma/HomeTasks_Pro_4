using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string inputFile = "input.txt"; 
			string outputFile = "output.txt";
			string inputText;
			string outputText;

			using (StreamReader reader = new StreamReader(inputFile))
			{
				inputText = reader.ReadToEnd();
			}

			outputText = ReplacePrepositions(inputText);

			using (StreamWriter writer = new StreamWriter(outputFile))
			{
				writer.WriteLine(outputText);
			}

			Console.WriteLine("Замена прийменников виконана успішно.");
		}

		static string ReplacePrepositions(string text)
		{
			string prepositionPattern = @"\b(в|на|за|під|по|у|біля|з|про)\b";

			string replacedText = Regex.Replace(text, prepositionPattern, "ГАВ!", RegexOptions.IgnoreCase);

			return replacedText;
		}
	}
}