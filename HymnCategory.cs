using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class HymnCategory : UITableViewController
    {
        public HymnCategory (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			hymCategory.BackgroundColor = GeneralVariables.backColorSelected;
			string[] catSource = new string[GeneralVariables.hymns.Length];
			for (int i = 0; i < catSource.Length; i++)
			{
				catSource[i] = GeneralVariables.hymns[i].Substring(0, GeneralVariables.hymns[i].Length-4);
			}
			hymCategory.Source = new HymnCategorySource(catSource, this);
		}
    }
}