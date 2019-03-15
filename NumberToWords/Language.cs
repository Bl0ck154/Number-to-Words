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
	}
}
