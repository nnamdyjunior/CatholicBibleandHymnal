using System;
using Foundation;
using UIKit;
using System.IO;


namespace CatholicBibleandHymnal
{
	public class SelSettingTableSource : UITableViewSource
	{
		protected string[] tableItems1;
		//protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		UIFont font;

		public SelSettingTableSource(string[] items1, UIViewController owner)
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

			if (GeneralVariables.settingSelected == "Font")
			{
				font = UIFont.FromName(tableItems1[indexPath.Row], 15f);
			}
			else
			{
				font = GeneralVariables.fontSelected;
			}

			var stringAttributes2 = new UIStringAttributes
			{
				Font = font,
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
			if (GeneralVariables.settingSelected == "Background Color" || GeneralVariables.settingSelected == "Font Color")
			{
				return GeneralVariables.colorOptions.Length;
			}
			else if (GeneralVariables.settingSelected == "Font")
			{
				return GeneralVariables.fonts.Length;
			}
			else {
				return GeneralVariables.fontSize.Length;
			}
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			string[] cols = File.ReadAllLines(GeneralVariables.storagePath);

			if (GeneralVariables.settingSelected == "Background Color" && cols[1] != tableItems1[indexPath.Row])
			{
				ColorandSize.setBackColor(tableItems1[indexPath.Row]);
				File.WriteAllText(GeneralVariables.storagePath, tableItems1[indexPath.Row] + "\n"
								  + cols[1] + "\n" + cols[2] + "\n" + cols[3]);
			}
			else if (GeneralVariables.settingSelected == "Font Color" && cols[0] != tableItems1[indexPath.Row])
			{
				ColorandSize.setFontColor(tableItems1[indexPath.Row]);
				File.WriteAllText(GeneralVariables.storagePath, cols[0] + "\n"
								  + tableItems1[indexPath.Row] + "\n"
								  + cols[2] + "\n" + cols[3]);
			}
			else if (GeneralVariables.settingSelected == "Font")
			{
				ColorandSize.setFont(tableItems1[indexPath.Row]);
				File.WriteAllText(GeneralVariables.storagePath, cols[0] + "\n"
				                  + cols[1] + "\n"
								  + tableItems1[indexPath.Row] + "\n" + cols[3]);
			}
			else if (GeneralVariables.settingSelected == "Font Size")
			{
				ColorandSize.setFontSize(tableItems1[indexPath.Row]);
				File.WriteAllText(GeneralVariables.storagePath, cols[0] + "\n"
								  + cols[1] + "\n"
								  + cols[2] + "\n" + tableItems1[indexPath.Row]);
			}
			else
			{
				UIAlertController uac = UIAlertController.Create("WARNING!", "\n\nBackground color cannot be the same as font color", UIAlertControllerStyle.Alert);
				uac.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				owner.PresentViewController(uac, true, null);
			}

			tableView.DeselectRow(indexPath, true);

		}

	}
}



