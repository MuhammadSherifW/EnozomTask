using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;

namespace ConsoleApp6
{
	class Program
	{
		static void Main(string[] args)
		{

			StreamReader reader = new StreamReader(@"C:\Users\muh0s\Desktop\annual-enterprise-survey-2020-financial-year-provisional-csv.csv");
			//StreamReader reader = new StreamReader(@"C:\Users\muh0s\Desktop\testcase.csv");

			StringBuilder thirdColumnContent = new StringBuilder();
			int rowNumber = 0;
			while (!reader.EndOfStream)
			{
				if (rowNumber % 2 == 0)
				{
					reader.ReadLine(); // igonore even row 
				}
				else
				{
					string[] rowValues = reader.ReadLine().Split(',');
					thirdColumnContent.Append( rowValues[2]);
				}
				rowNumber++;
			}

			MD5 md5 = MD5.Create();
			byte[] contentInBytes = Encoding.ASCII.GetBytes(thirdColumnContent.ToString());
			byte[] HashValueinBytes = md5.ComputeHash(contentInBytes);
			StringBuilder hashValueInString = new StringBuilder();
			for (int i = 0; i < HashValueinBytes.Length; i++)
			{
				hashValueInString.Append(HashValueinBytes[i].ToString("X2"));
			}
			Console.WriteLine(hashValueInString.ToString());


		}
	}
}
