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
		public Language()
		{
			dictionary = new Dictionary<int, string>();
		}
		public void Add(int value, string translation)
		{
			this.dictionary[value] = translation;
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
		public string Get(int value)
		{
			string answer;
			dictionary.TryGetValue(value, out answer);
			return answer;
		}
		public string GetEnding(int value, int hundreds)
		{
			string ending = "";
			string strVal = value.ToString();
			char endingChar = strVal[strVal.Length - 1];
			if (hundreds >= 1000000)
			{
				switch (endingChar)
				{
					case '1':
						break;
					case '2':
					case '3':
					case '4':
						ending = "а";
						break;
					default:
						ending = "ов";
						break;
				}
			}
			else if (hundreds >= 1000)
			{
				switch (endingChar)
				{
					case '1':
						ending = "а";
						break;
					case '2':
					case '3':
					case '4':
						ending = "и";
						break;
					default:
						ending = "";
						break;
				}
			}
			return ending;
		}
	}
}
