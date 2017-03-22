using System;
using System.IO;
using System.Collections;


namespace CatholicBibleandHymnal
{
	public class Search
	{
		public ArrayList slist = new ArrayList();
		public ArrayList sublist = new ArrayList();
		public static string dirr;

		public Search()
		{
		}

		public void searchFor(string rootDir, string phrase)
		{

				GeneralVariables.query = phrase;
				string[] subDirs = Directory.GetDirectories(rootDir);

				foreach (string subDir in subDirs)
				{
					string[] files = Directory.GetFiles(subDir);

					foreach (string file in files)
					{
						string content = File.ReadAllText(file);

					if (content.ToLower().Contains(phrase.ToLower()) || file.ToLower().Contains(phrase.ToLower()))
						{
							slist.Add(file);
						int startIndex = content.ToLower().IndexOf(phrase.ToLower());
						if (startIndex >= 0)
						{
							sublist.Add(content.Substring(startIndex));//, GeneralVariables.query.Length));
						}
						else {
							sublist.Add("");
						}
						}
					}//end 2nd foreach
				}//end 1st foreach

			//slist.Add("");  //so slist won't be null, resulting in an error
			if (slist != null)
			{
				GeneralVariables.searchResults = slist.ToArray(typeof(string)) as string[];
				GeneralVariables.subSearchResults = sublist.ToArray(typeof(string)) as string[];

			}
			else 
			{
				string[] eee = { "", "", "", "" };
				GeneralVariables.searchResults = eee;
			}
			
		}//end searchFor
	}//end Search class
}//end namespace

