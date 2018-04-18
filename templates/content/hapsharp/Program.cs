using System;
using HapSharp;
using HapSharp.Accessories;
using HapSharp.MessageDelegates;

namespace NewApp
{
    class Program
    {
    	const string HapNodeJsPath = "/home/pi/HapSharp/HAP-NodeJS";

        static void Main (string[] args)
        {
            //This class provides the handling of the output log messages
			var monitor = new ConsoleMonitor ();

			//Our HAP session manages our runner, this step only adds our prefered monitor
			var session = new HapSession (monitor) {
				Sudo = true, //if we want execute our host with privileges
			};

			//Now we need add Accessories and MessagesDelegates
			//Our first element must be a bridgeCore, it contains all other accesories in session
			session.Add<BridgedCoreMessageDelegate> (new BridgedCore ("Raspian Net Bridge", "22:32:43:54:45:14"));

			//Now, we add all the accessories from the Shared Project
			session.Add<CustomLightMessageDelegate> (new LightAccessory ("Light 1", "A1:32:45:66:57:73"));

			session.Start (HapNodeJsPath);

			while (true) { }
        }
    }
}
