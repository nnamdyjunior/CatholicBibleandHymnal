using System;
using System.IO;
using Foundation;
using UIKit;


namespace CatholicBibleandHymnal
{
	public class SettingsTableSource : UITableViewSource
	{
		protected string[] tableItems1;
		//protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		public SettingsTableSource(string[] items1, UIViewController owner)
		{
			tableItems1 = items1;
			this.owner = owner;
		}

		//adding content to each cell in the table
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//throw new NotImplementedException();
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			//if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}

			var stringAttributes2 = new UIStringAttributes
			{
				Font = GeneralVariables.fontSelected,
				ForegroundColor = GeneralVariables.fontColorSelected
			};
			var celltext = new NSMutableAttributedString(tableItems1[indexPath.Row]);
			celltext.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, celltext.Length));
			cell.TextLabel.AttributedText = celltext;
			cell.BackgroundColor = GeneralVariables.backColorSelected;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			//throw new NotImplementedException();
			return GeneralVariables.settings.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			GeneralVariables.settingSelected = tableItems1[indexPath.Row];

			//initialize a new view (the sub-settings view)
			SelSettingTable sst = owner.Storyboard.InstantiateViewController("selSettingTable") as SelSettingTable;
			sst.Title = GeneralVariables.settingSelected;
			owner.NavigationController.PushViewController(sst, true);

			tableView.DeselectRow(indexPath, true);

		}

	}
}



