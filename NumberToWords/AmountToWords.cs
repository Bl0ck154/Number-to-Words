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

		public string Convert(int amount, int fraction)
		{
			string whole = amount.ToString();
			return GetWords(whole) + " рублей и " + GetWords(fraction.ToString()) + " копеек";
		}

		private string GetWords(string input)
		{
			int i = 1;

			string words = "";

			while (input.Length > 0)
			{
				string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);

				input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

				int num = int.Parse(_3digits);
				
				_3digits = GetWord(num);

				if (i > 1)
				{
					_3digits += ' ' + language.Get(i);
					_3digits += language.GetEnding(num, i) + ' ';
				}

				words = _3digits + words;

				i *= 1000;
			}
			return words;
		}
		private string GetWord(int num)
		{
			string word = "";
			int tmp;

			if (num > 99 && num < 1000)
			{
				tmp = num / 100 * 100;
				word += language.Get(tmp) + " ";
				num = num % 100;
			}

			if (num > 19 && num < 100)
			{
				tmp = num / 10 * 10;
				word += language.Get(tmp) + " ";
				num = num % 10;
			}

			if (num > 0 && num < 20)
			{
				word += language.Get(num);
			}

			return word;
		}
	}
}
