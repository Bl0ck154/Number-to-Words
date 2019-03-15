using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
	class Currency
	{
		public string Fraction { get; set; } = "копе";
		public string GetName(int value)
		{
			string basis = "рубл";
			string ending = "";
			string strVal = value.ToString();
			char endingChar = strVal[strVal.Length - 1];
			switch (endingChar)
			{
				case '1':
					ending = "ь";
					break;
				case '2':
				case '3':
				case '4':
					ending = "я";
					break;
				default:
					ending = "ей";
					break;
			}

			return basis + ending;
		}
		public string GetNameFraction(int value)
		{
			string basis = "копе";
			string ending = "";
			string strVal = value.ToString();
			char endingChar = strVal[strVal.Length - 1];
			switch (endingChar)
			{
				case '1':
					ending = "йка";
					break;
				case '2':
				case '3':
				case '4':
					ending = "йки";
					break;
				default:
					ending = "ек";
					break;
			}

			return basis + ending;
		}
	}
}
