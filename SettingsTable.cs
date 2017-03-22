using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class SettingsTable : UITableViewController
    {
        public SettingsTable (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			settingsTab.BackgroundColor = GeneralVariables.backColorSelected;
			settingsTab.Source = new SettingsTableSource(GeneralVariables.settings, this);
		}
    }
}