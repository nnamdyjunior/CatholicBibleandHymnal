using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class BooksTable : UITableViewController
    {
        public BooksTable (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			bookTable.BackgroundColor = GeneralVariables.backColorSelected;
			bookTable.Source = new BooksTableSource(GeneralVariables.numOfChapters, this);
		}
    }
}