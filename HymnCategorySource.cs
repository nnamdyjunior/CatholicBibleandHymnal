using System;
using System.IO;
using Foundation;
using UIKit;


namespace CatholicBibleandHymnal
{
	public class HymnCategorySource : UITableViewSource
	{
		protected string[] tableItems1;
		//protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		public HymnCategorySource(string[] items1, UIViewController owner)
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
			//cell.TextLabel.Text = tableItems1[indexPath.Row];
			cell.BackgroundColor = GeneralVariables.backColorSelected;
			//cell.TextLabel.TextColor = GeneralVariables.fontColorSelected;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			//throw new NotImplementedException();
			return GeneralVariables.hymns.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//set the source directory
			GeneralVariables.hymnSelected = tableItems1[indexPath.Row];
			string hymDir = "Hymns/" + GeneralVariables.hymnCatSelected + "/" + GeneralVariables.hymnSelected;

			//read file contents and store in a variable
			try
			{
				GeneralVariables.hymnContent = File.ReadAllText(hymDir + ".txt");
			}
			catch (IOException)
			{
				GeneralVariables.hymnContent = hymDir;
			}

			/*
			//initialize a new view (the text view)
			HymnTextView htv = owner.Storyboard.InstantiateViewController("hymnTextView") as HymnTextView;
			htv.Title = GeneralVariables.hymnSelected;
			owner.NavigationController.PushViewController(htv, true);*/

			var exp2 = owner.Storyboard.InstantiateViewController("experiment2") as Experiment2;
			exp2.Title = GeneralVariables.hymnSelected;
			owner.NavigationController.PushViewController(exp2, true);

			tableView.DeselectRow(indexPath, true);

		}

	}
}






