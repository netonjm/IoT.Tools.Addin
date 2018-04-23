using System;
using Xwt;

namespace NewApp
{
	public class MainWindow : Window
	{
		int count = 0;
		readonly Button button;

		public MainWindow () 
		{
			var box = new VBox ();
			Content = box;

			var label = new Label ("This is a test");
			box.PackStart (label, false);

			button = new Button ("Click Me");
			button.Clicked += OnBtnActionClicked;
			box.PackStart (button, false);
			this.Show ();
		}

		protected override void OnClosed ()
		{
			Xwt.Application.Exit ();
		}

		protected void OnBtnActionClicked (object sender, EventArgs e)
		{
			button.Label = string.Format ("You pressed {0} times.", ++count);
		}
	}
}