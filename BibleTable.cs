using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class BibleTable : UITableViewController
    {
        public BibleTable (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			bibTable.BackgroundColor = GeneralVariables.backColorSelected;
			GeneralVariables.oldTestSize = GeneralVariables.oldTestBooks.Length;
			GeneralVariables.newTestSize = GeneralVariables.newTestBooks.Length;

			bibleSearch.SearchButtonClicked += searchFor();

			bibTable.Source = new BibleTableSource(GeneralVariables.oldTestBooks, GeneralVariables.newTestBooks, this);

		}

		public EventHandler searchFor()
		{
			return delegate {
				Search thisSearch = new Search();
				thisSearch.searchFor("Bible", bibleSearch.Text);
				BibleSearchResults sst = this.Storyboard.InstantiateViewController("bibleSearchResults") as BibleSearchResults;
				sst.Title = "Search Results"; //GeneralVariables.settingSelected;
				this.NavigationController.PushViewController(sst, true);
			};
		}

    }
}