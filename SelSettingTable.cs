using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class SelSettingTable : UITableViewController
    {
        public SelSettingTable (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			selSettingTab.BackgroundColor = GeneralVariables.backColorSelected;
			if (GeneralVariables.settingSelected == "Background Color" || GeneralVariables.settingSelected == "Font Color")
			{
				selSettingTab.Source = new SelSettingTableSource(GeneralVariables.colorOptions, this);
			}
			else if (GeneralVariables.settingSelected == "Font")
			{
				string[] fonts = UIFont.FamilyNames;
				GeneralVariables.fonts = fonts;
				selSettingTab.Source = new SelSettingTableSource(fonts, this);
			}
			else {
				string[] sizes = new string[GeneralVariables.fontSize.Length];
				for (int i = 0; i < sizes.Length; i++)
				{
					sizes[i] = GeneralVariables.fontSize[i].ToString();
				}
				selSettingTab.Source = new SelSettingTableSource(sizes, this);
			}
		}
    }
}