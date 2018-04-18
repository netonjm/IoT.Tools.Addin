namespace NewApp
{
    class Program
    {
        static void Main (string[] args)
        {
			using (var exampleHub = new MyCustomHub ()) {
				exampleHub.Start (1000, true);
			};
        }
    }
}
