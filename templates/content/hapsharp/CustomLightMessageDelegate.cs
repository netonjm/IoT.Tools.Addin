using HapSharp.Accessories;
using HapSharp.MessageDelegates;
using System;

namespace NewApp
{
	class CustomLightMessageDelegate : LightMessageDelegate
	{
		bool enabled;

		public CustomLightMessageDelegate (LightAccessory accessory) : base (accessory)
		{
		}

		public override void OnChangePower (bool value)
		{
			enabled = value;
			Console.Write ("Received: {0}", value);
		}

		public override bool OnGetPower ()
		{
			return enabled;
		}
	}
}