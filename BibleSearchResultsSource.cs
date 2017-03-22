using System;
using System.IO;
using UIKit;
using Foundation;


namespace CatholicBibleandHymnal
{
	public class BibleSearchResultsSource : UITableViewSource
	{
		protected string[] tableItems1;
		//protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		public BibleSearchResultsSource(string[] items1, UIViewController owner)
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
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			}

			var stringAttributes2 = new UIStringAttributes
			{
				Font = GeneralVariables.fontSelected,
				ForegroundColor = GeneralVariables.fontColorSelected
			};
			var celltext = new NSMutableAttributedString(tableItems1[indexPath.Row].Split('/')[2].Substring(0, tableItems1[indexPath.Row].Split('/')[2].Length - 4));
			celltext.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, celltext.Length));
			cell.TextLabel.AttributedText = celltext;
			cell.BackgroundColor = GeneralVariables.backColorSelected;
			//cell.TextLabel.TextColor = GeneralVariables.fontColorSelected;
			cell.DetailTextLabel.Text = GeneralVariables.subSearchResults[indexPath.Row];
			cell.DetailTextLabel.TextColor = GeneralVariables.fontColorSelected;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			//throw new NotImplementedException();
			return GeneralVariables.searchResults.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			//read file contents and store in a variable
			try
			{
				GeneralVariables.searchText = File.ReadAllText(tableItems1[indexPath.Row]);
			}
			catch (IOException)
			{
				GeneralVariables.searchText = tableItems1[indexPath.Row];
			}


			//initialize a new view
			SearchResultText srt = owner.Storyboard.InstantiateViewController("searchResultText") as SearchResultText;
			srt.Title = tableItems1[indexPath.Row].Split('/')[2].Substring(0, tableItems1[indexPath.Row].Split('/')[2].Length - 4); ;
			owner.NavigationController.PushViewController(srt, true);

			tableView.DeselectRow(indexPath, true);

		}

	}
}

