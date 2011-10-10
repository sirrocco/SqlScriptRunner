using System;
using System.Windows.Forms;

namespace SiqualRunner
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			

			Bootstrapper.Start();
			//args = Environment.GetCommandLineArgs();

		
				
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			
		}
	}
}
