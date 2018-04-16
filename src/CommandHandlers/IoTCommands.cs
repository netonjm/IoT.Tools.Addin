using System;
using Gtk;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Projects;
using System.Collections.Generic;
using MonoDevelop.Core.Execution;
using System.Threading;
using MonoDevelop.Core;
using System.Diagnostics;
using Xamarin.VisualStudio.IoT.ProjectSystem;

namespace Xamarin.VisualStudio.IoT.CommandHandlers
{
	public class SshCommandHandler : CommandHandler
	{
		static readonly ITracer tracer = Tracer.Get<SshCommandHandler> ();

		protected override void Update (CommandInfo info)
		{
			var executionTargerSelected =  IdeApp.Workspace.ActiveExecutionTarget as IoTDeviceExecutionTarget;
			var serverInteractive = executionTargerSelected?.ServerInteractive;
			info.Enabled = serverInteractive != null;
			info.Visible = IoTFramework.StartupItem?.IsIoTProjectFlavor() ?? false;
		}

		protected async override void Run ()
		{
			var executionTarger = IdeApp.Workspace.ActiveExecutionTarget as IoTExecutionTarget;
			var server = executionTarger?.ServerInteractive?.CurrentServer;
			if (server == null)
				return;

			tracer.Info ($"Opening SSH with {server.FullName}...");

			ProcessAsyncOperation oper = null;

			bool pauseExternalConsole = false;

			var cs = new CancellationTokenSource ();
			var monitor = new ProgressMonitor (cs);
			try {
				var console = ExternalConsoleFactory.Instance.CreateConsole (!pauseExternalConsole, monitor.CancellationToken);
				oper = Runtime.ProcessService.StartConsoleProcess ("ssh", $"{server.Username}@{server.IpAddress.ToString ()}",
							new FilePath ("$HOME"), console, null);

				var stopper = monitor.CancellationToken.Register (oper.Cancel);
				await oper.Task;
				stopper.Dispose ();

				if (oper.ExitCode != 0) {
					var msgError = $"Custom command failed (exit code: {oper.ExitCode});";
					tracer.Error (msgError);
					monitor.ReportError (msgError, null);
				}
			} catch (Exception ex) {
				LoggingService.LogError (ex.ToString ());
			}
		}
	}
}
