using Foundation;
using System;
using UIKit;
using System.IO;

namespace CatholicBibleandHymnal
{
    public partial class HymnTable : UITableViewController
    {
        public HymnTable (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			hymTable.BackgroundColor = GeneralVariables.backColorSelected;
			string[] categories = Directory.GetDirectories("Hymns");
			GeneralVariables.hymnCats = new string[categories.Length];
			for (int i = 0; i < categories.Length; i++)
			{
				GeneralVariables.hymnCats[i] = categories[i].Substring(6);
			}

			hymnSearch.SearchButtonClicked += searchFor();

			hymTable.Source = new HymnTableSource(GeneralVariables.hymnCats, this);
		}

		public EventHandler searchFor()
		{
			return delegate
			{
				Search thisSearch = new Search();
				thisSearch.searchFor("Hymns", hymnSearch.Text);
				BibleSearchResults sst = this.Storyboard.InstantiateViewController("bibleSearchResults") as BibleSearchResults;
				sst.Title = "Search Results"; //GeneralVariables.settingSelected;
				this.NavigationController.PushViewController(sst, true);
			};
		}
    }
}