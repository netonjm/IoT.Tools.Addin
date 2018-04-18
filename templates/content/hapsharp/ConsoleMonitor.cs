using System;
using HapSharp;

namespace NewApp
{
	class ConsoleMonitor : IMonitor
	{
		public void WriteLine (string message)
		{
			Console.WriteLine (message);
		}
	}
}
