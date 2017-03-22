using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class BibleSearchResults : UITableViewController
    {
        public BibleSearchResults (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();



			bibSearchResults.Source = new BibleSearchResultsSource(GeneralVariables.searchResults, this);
		}
    }
}