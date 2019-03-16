using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
	class Language
	{
		Dictionary<int, string> dictionary;
		Dictionary<int, string> sheDictionary;
		Dictionary<Currency, CurrencyNameWithEnding> currenciesWithEndings;
		public Language()
		{
			dictionary = new Dictionary<int, string>();
			sheDictionary = new Dictionary<int, string>();
			currenciesWithEndings = new Dictionary<Currency, CurrencyNameWithEnding>();
		}
		public void Add(int value, string translation)
		{
			this.dictionary[value] = translation;
		}
		public void AddShe(int value, string translation)
		{
			this.sheDictionary[value] = translation;
		}
		public void AddRange(string[] translations, int startsFrom, int step)
		{
			int pos = startsFrom;
			foreach (var item in translations)
			{
				Add(pos, item);
				pos += step;
			}
		}
		public void AddSheRange(string[] translations, int startsFrom, int step)
		{
			int pos = startsFrom;
			foreach (var item in translations)
			{
				AddShe(pos, item);
				pos += step;
			}
		}
		public string Get(int value)
		{
			string answer;
			dictionary.TryGetValue(value, out answer);
			return answer;
		}
		public string Get(int value, bool sheWord = false)
		{
			string answer;
			if (sheWord)
			{
				answer = GetShe(value);
			}
			else
			{
				dictionary.TryGetValue(value, out answer);
			}

			return answer;
		}
		public string GetShe(int value)
		{
			string answer;
			sheDictionary.TryGetValue(value, out answer);
			if (answer == null)
				answer = Get(value);

			return answer;
		}
		public string GetEnding(int value, int hundreds)
		{
			string ending = "";
			string strVal = value.ToString();
			char prevEndingChar = strVal.Length == 1 ? ' ' : strVal[strVal.Length - 2];
			char endingChar = strVal[strVal.Length - 1];

			if (hundreds >= 1000)
			{
				bool limons = (hundreds >= 1000000);
				if (endingChar == '1' && prevEndingChar != '1')
				{
					ending = limons ? "" : "а";
				}
				else if(endingChar >= '2' && endingChar <= '4' && prevEndingChar != '1')
				{
					ending = limons ? "а" : "и";
				}
				else
				{
					ending = limons ? "ов" : "";
				}
			}

			return ending;
		}
		public void AddCurrency(Currency currency, CurrencyNameWithEnding names)
		{
			this.currenciesWithEndings[currency] = names;
		}
		public string GetCurrencyNameWithEnding(Currency currency, int value, bool fraction = false)
		{
			string name = fraction ? currenciesWithEndings[currency].Fraction : currenciesWithEndings[currency].Name;
			string[] endings = fraction ? currenciesWithEndings[currency].FractionEnding : currenciesWithEndings[currency].MainEnding;
			string ending = "";

			string strVal = value.ToString();
			char prevEndingChar = strVal.Length == 1 ? ' ' : strVal[strVal.Length - 2];
			char endingChar = strVal[strVal.Length - 1];

			if (endingChar == '1' && prevEndingChar != '1')
			{
				ending = endings[0];
			}
			else if (endingChar >= '2' && endingChar <= '4' && prevEndingChar != '1')
			{
				ending = endings[1];
			}
			else
			{
				ending = endings[2];
			}

			return name + ending;
		}
	}
}
