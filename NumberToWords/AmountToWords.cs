using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
	class AmountToWords
	{
		Currency currency;
		Language language;
		public AmountToWords(Language language, Currency currency)
		{
			this.language = language;
			this.currency = currency;
		}
		public string Convert(int amount, int fraction, bool amountSheWord = false, bool fractionSheWord = false)
		{
			string whole = amount.ToString();
			string fract = fraction.ToString();
			return GetWords(whole, amountSheWord) + " " + language.GetCurrencyNameWithEnding(currency, amount) + " "
				+ GetWords(fract, fractionSheWord) + " " + language.GetCurrencyNameWithEnding(currency, fraction, true) + " ";
		}
		public string Convert(string amount, bool amountSheWord = false, bool fractionSheWord = false)
		{
			string fraction = "";
			if (amount.Contains("."))
			{
				fraction = amount.Substring(amount.IndexOf(".") + 1);
				amount = amount.Remove(amount.IndexOf("."));
			}
			return Convert(int.Parse(amount), int.Parse(fraction), amountSheWord, fractionSheWord);
		}
		private string GetWords(string input, bool sheWord = false)
		{
			int multiplier = 1;
			string words = "";

			while (input.Length > 0)
			{
				string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);

				input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

				int num = int.Parse(_3digits);
				
				_3digits = GetWord(num, sheWord);

				if (multiplier > 1)
				{
					_3digits += ' ' + language.Get(multiplier);
					_3digits += language.GetEnding(num, multiplier) + ' ';
				}

				words = _3digits + words;

				multiplier *= 1000;
			}

			return words;
		}
		private string GetWord(int num, bool sheWord = false)
		{
			string word = "";
			int tmp;

			if (num > 99 && num < 1000)
			{
				tmp = num / 100 * 100;
				word += language.Get(tmp, sheWord) + " ";
				num = num % 100;
			}

			if (num > 19 && num < 100)
			{
				tmp = num / 10 * 10;
				word += language.Get(tmp, sheWord) + " ";
				num = num % 10;
			}

			if (num >= 0 && num < 20)
			{
				word += language.Get(num, sheWord);
			}

			return word;
		}
	}
}
