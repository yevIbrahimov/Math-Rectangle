using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanMath.Impl
{
	public static class Service
	{
		public static int Evaluate(string expression)
		{
			if (expression == null || expression == String.Empty)
			{
				throw new ArgumentNullException();
			}
			if (Validation(expression))
			{
				throw new ArgumentException();
			}
			
			string romNumber = "";
			int firstNum = 0, secondNum = 0, counter = 0;
			char sign = ' ';
			for (int i = 0; i <= expression.Length; i++)
			{
				if (i != expression.Length && expression[i] != '+' && expression[i] != '-' && expression[i] != '*' )
				{
					romNumber += expression[i];
				}
				else
				{
					counter++;
					if (counter == 1)
					{
						firstNum = ToArabMethod(romNumber);
						romNumber = "";
						sign = expression[i];
					}
					else
					{
						secondNum = ToArabMethod(romNumber);
						firstNum = Operation(firstNum, secondNum, sign);
						romNumber = "";
						if (i != expression.Length)
						{
							sign = expression[i];
						}	
					}
				}
			}
			return firstNum;
		}
		private static int ToArabMethod(string romNumber)
		{
			Dictionary<char, int> romToArab = new Dictionary<char, int>()
			{
				{'M',1000}, {'D',500}, {'C',100}, {'L',50},{'X',10}, {'V',5}, {'I',1}
			};
			int result = 0;
			for (int i = 0; i < romNumber.Length; i+=2)
			{
				if (romToArab[romNumber[i]] < romToArab[romNumber[i + 1]])
				{
					result += romToArab[romNumber[i + 1]] - romToArab[romNumber[i]];
				}
				else
				{
					result += romToArab[romNumber[i + 1]] + romToArab[romNumber[i]];
				}
			}
			return result;
		}
		private static int Operation(int firstNum, int secondNum, char sign)
		{
			switch (sign)
			{
				case '+':
					return firstNum + secondNum;
				case '-':
					return firstNum - secondNum;
				case '*':
					return firstNum * secondNum;
				default:
					throw new InvalidOperationException();
			}
		}
		private static bool Validation(string expression)
		{
			var valid = new Regex("^[MDCLXVI]{1,}([*+-]{1}[MDCLXVI]{1,}){1,}$");
			var result = valid.IsMatch(expression);
			return result;
		}
	}
}
