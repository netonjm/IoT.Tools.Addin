using System;
using IoTSharp.Components;

namespace NewApp
{
	class MyCustomHub : IoTHub
	{
		int counter;
		const int Max = 5;

		public override void OnInitialize ()
		{
			Console.WriteLine ("OnInitialize");
		}

		public override void OnUpdate ()
		{
			Console.WriteLine ("OnUpdate");

			if (counter == Max) {
				Stop ();
				Console.WriteLine ("Finished! {0}/{1}", counter, Max);
				return;
			}

			counter++;
			Console.WriteLine ("Loop {0}/{1}", counter, Max);
		}
	}
}
