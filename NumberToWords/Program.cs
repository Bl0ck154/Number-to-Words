using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
	class Program
	{
		static void Main(string[] args)
		{
			//string[] Ones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
			//	"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
			//	"Seventeen", "Eighteen", "Ninteen" };

			//string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fift", "Sixty",
			//	"Seventy", "Eighty", "Ninty" };

			//Language eng = new Language();
			//eng.AddRange(Ones, 1, 1);
			//eng.AddRange(Tens, 10, 10);

			string[] OnesRu = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять",
				"десять", "одинадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать",
				"семьнадцать", "восемьнадцать", "девятнадцать" };

			string[] TensRu = { "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят",
				"семьдесят", "восемьдесят", "девяносто" };

			string[] HundredsRu = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };


			Language rus = new Language();
			rus.AddRange(OnesRu, 0, 1);
			rus.AddRange(TensRu, 20, 10);
			rus.AddRange(HundredsRu, 100, 100);
			rus.AddSheRange(new string[] { "одна", "две" }, 1, 1);
			rus.Add(1000, "тысяч");
			rus.Add(1000000, "миллион");
			rus.Add(1000000000, "миллиард");

			Currency currency = new Currency("Рубль");

			CurrencyNameWithEnding currencyNames = new CurrencyNameWithEnding() { Name = "рубл", Fraction = "копе",
				MainEnding = new string[] { "ь", "я", "ей", }, FractionEnding = new string[] { "йка", "йки", "ек" } };

			rus.AddCurrency(currency, currencyNames);

			AmountToWords amountToWords = new AmountToWords(rus, currency);

			Console.WriteLine("Введенное число: 123003341.1");
			Console.WriteLine(amountToWords.Convert(123003341, 1, false, true));

			while(true)
			{
				Console.WriteLine("Введите число: ");
				string line = Console.ReadLine();

				Console.WriteLine(amountToWords.Convert(line, false, true));
			}

			Console.ReadKey();
		}
	}
}
