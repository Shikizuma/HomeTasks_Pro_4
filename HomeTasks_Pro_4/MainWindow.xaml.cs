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

namespace HomeTasks_Pro_4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
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
			MatchCollection linkMatches = Regex.Matches(html, linkPattern);
			StringBuilder stringBuilder = new StringBuilder();
			if (linkMatches.Count > 0)
			{
				foreach (Match match in linkMatches)
				{
					stringBuilder.Append(match.Groups[1].Value);
				}
			}

			using (StreamWriter writer = new StreamWriter("test.txt"))
			{
				writer.WriteLine(stringBuilder.ToString());
			}
		}

		private void OpenTxtButton_Click(object sender, RoutedEventArgs e)
		{
			string filePath = "test.txt"; 

			try
			{
				Process.Start(filePath);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Произошла ошибка при открытии файла: " + ex.Message);
			}
		}
	}
}
