using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace HomeTasks_Pro_4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		const string FILE = "test.txt";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ParseButton_Click(object sender, RoutedEventArgs e)
		{
			string url = URLTextBox.Text; 
			WebClient client = new WebClient();
			string html = client.DownloadString(url);
			string linkPattern = @"<a\s+[^>]*href\s*=\s*['""]([^'""]*)['""][^>]*>";
			string phonePattern = @"\+\d{12}";
			string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

			MatchCollection linkMatches = Regex.Matches(html, linkPattern);
			MatchCollection phoneMatches = Regex.Matches(html, phonePattern);
			MatchCollection emailMatches = Regex.Matches(html, emailPattern);

			List<string> strings = new List<string>();
			strings.Add("Ланки на веб странці:");
			strings.AddRange(WriteMatches(linkMatches));
			strings.Add("Телефони на веб странці:");
			strings.AddRange(WriteMatches(phoneMatches));
			strings.Add("Емейли на веб странці:");
			strings.AddRange(WriteMatches(emailMatches));

			WriteToFile(FILE, strings);
		}

		private List<string> WriteMatches(MatchCollection matches)
		{
			List<string> strings = new List<string>();
			if (matches.Count > 0)
			{
				foreach (Match match in matches)
				{
					strings.Add(match.Value);
				}
			}
			return strings;
		}

		private void WriteToFile(string fileName, List<string> strings)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				foreach (string match in strings)
				{
					writer.WriteLine(match);
				}
			}
		}
		private void OpenTxtButton_Click(object sender, RoutedEventArgs e)
		{
			string filePath = FILE;

			using (StreamReader reader = new StreamReader(filePath))
			{
				string fileContent = reader.ReadToEnd();
				ShowTextBox.Text = fileContent;
			}
		}
	}
}
