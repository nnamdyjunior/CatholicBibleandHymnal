using System;
using System.IO;
using UIKit;

namespace CatholicBibleandHymnal
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			homeImage.ClipsToBounds = true;//.Bounds.Width = UIScreen.MainScreen.Bounds.Width;
										   //homeImage.ContentMode = UIViewContentMode.ScaleAspectFit;
										   //subStack.SizeToFit();

			GeneralVariables.storagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cbahsettings.txt";

			if (File.Exists(GeneralVariables.storagePath))
			{
				string[] cols = File.ReadAllLines(GeneralVariables.storagePath);
				ColorandSize.setBackColor(cols[0]);
				ColorandSize.setFontColor(cols[1]);
				ColorandSize.setFont(cols[2]);
				ColorandSize.setFontSize(cols[3]);
			}
			else {
				string[] cola = File.ReadAllLines("Settings.txt");
				File.WriteAllLines(GeneralVariables.storagePath, cola);

				string[] cols = File.ReadAllLines(GeneralVariables.storagePath);
				ColorandSize.setBackColor(cols[0]);
				ColorandSize.setFontColor(cols[1]);
				ColorandSize.setFont(cols[2]);
				ColorandSize.setFontSize(cols[3]);
			}

			//ColorandSize cas = new ColorandSize();



		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		//prevent it from auto rotating
		public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
		{
			return UIInterfaceOrientation.Portrait;
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.Portrait;
		}

		public override bool ShouldAutorotate()
		{
			return false;
		}

		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			if (toInterfaceOrientation == UIInterfaceOrientation.Portrait)
			{
				return true;
			}
			else 
			{
				return false;
			}
		}

	}
}

