using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var result = Service.Evaluate("IV+II");
			System.Console.ReadKey();
		}
	}
}
