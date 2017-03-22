using System;
using Foundation;
using UIKit;
using System.IO;


namespace CatholicBibleandHymnal
{
	public class ColorandSize
	{
		public ColorandSize()
		{
		}

		public static void setBackColor(string col)
		{
			if (col == "Blue")
			{
				GeneralVariables.backColorSelected = UIColor.Blue;
			}
			else if (col == "Red")
			{
				GeneralVariables.backColorSelected = UIColor.Red;
			}
			else if (col == "Black")
			{
				GeneralVariables.backColorSelected = UIColor.Black;
			}
			else if (col == "Gray")
			{
				GeneralVariables.backColorSelected = UIColor.Gray;
			}
			else if (col == "White")
			{
				GeneralVariables.backColorSelected = UIColor.White;
			}
		}

		public static void setFontColor(string col)
		{
			switch (col)
			{
				case("Blue") : GeneralVariables.fontColorSelected = UIColor.Blue; break;
				case("Black"): GeneralVariables.fontColorSelected = UIColor.Black; break;
				case ("Gray"): GeneralVariables.fontColorSelected = UIColor.Gray; break;
				case ("White"): GeneralVariables.fontColorSelected = UIColor.White; break;
				case ("Red"): GeneralVariables.fontColorSelected = UIColor.Red; break;
			}
		}

		public static void setFont(string font)
		{
			string[] settings = File.ReadAllLines(GeneralVariables.storagePath);
			GeneralVariables.fontSelected = UIFont.FromName(font, float.Parse(settings[3]));
		}

		public static void setFontSize(string size)
		{
			string[] settings = File.ReadAllLines(GeneralVariables.storagePath);
			GeneralVariables.fontSelected = UIFont.FromName(settings[2], float.Parse(size));

		}
	}
}

