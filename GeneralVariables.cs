using System;
using UIKit;
using Foundation;
using System.IO;


namespace CatholicBibleandHymnal
{
	public static class GeneralVariables
	{
		//number of elements in the array
		public static int oldTestSize { get; set; } = 0;
		public static int newTestSize { get; set; } = 0;

		//books in the bible
		public static string[] oldTestBooks { get; set; } = {"Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", 
			"Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", 
			"Ezra", "Nehemiah", "Tobit", "Judith", "Esther", "1 Maccabees", "2 Maccabees",  "Job", "Psalms", "Proverbs", 
			"Ecclesiastes", "Song of Solomon", "Wisdom of Solomon", "Ecclesiasticus (Sirach)", "Isaiah", "Jeremiah", "Lamentations", "Baruch", 
			"Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", 
			"Haggai", "Zechariah", "Malachi"};
		public static string[] newTestBooks { get; set; } = {"Matthew", "Mark", "Luke", "John", "Acts", "Romans", 
			"1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", 
			"2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", 
			"1 John", "2 John", "3 John", "Jude", "Revelation"};

		//tables in the bible section
		public static string selectedBook { get; set; }
		public static string selectedDir { get; set; }
		public static string[] numOfChapters { get; set; } = { };
		public static string chapterContent { get; set; }

		//tables in the hymns section
		public static string[] hymnCats { get; set; } = { };
		public static string[] hymns { get; set; } = { };
		public static string hymnCatSelected { get; set; }
		public static string hymnSelected { get; set; }
		public static string hymnContent { get; set; }

		//settings section
		public static string[] settings { get; set; } = {"Background Color", "Font", "Font Size", "Font Color" };
		public static string[] colorOptions { get; set; } = {"Red", "Blue", "Gray", "Black", "White" };
		public static int[] fontSize { get; set; } = { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
		public static string backColor { get; set; } 
		public static string fontColor { get; set; }
		public static string settingSelected { get; set; }

		public static string[] colorSet = File.ReadAllLines("Settings.txt");
		public static UIColor backColorSelected { get; set; }// = ColorandSize.backCol();
		public static UIColor fontColorSelected { get; set; }// = ColorandSize.fontCol();

		public static string[] fonts { get; set; }
		public static UIFont fontSelected { get; set; }
		public static float fontSizeSelected { get; set; }

		public static string storagePath { get; set; }

		//search section
		public static string[] searchResults { get; set; }
		public static string[] subSearchResults { get; set; }
		public static string searchText { get; set; } 
		public static string query { get; set; }
		/*public GeneralVariables()
		{
		}*/
	}
}

