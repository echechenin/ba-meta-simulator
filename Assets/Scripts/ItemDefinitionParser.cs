using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ItemDefinitionParser{

	static public List<ItemDefinition> ParseItemDefinition()
	{
		List<ItemDefinition> itemsDefs = new List<ItemDefinition> ();;
		string csvFilePath = "csv/ItemDefinitions";
		TextAsset csvFile = Resources.Load<TextAsset>(csvFilePath);
		string[,] source = SplitCsvGrid (csvFile.text);

		for (int i = 1; i < source.GetUpperBound(1); i++) 
		{
			var itemDef = new ItemDefinition (
				source [0, i],
				(ItemType) Enum.Parse(typeof(ItemType), source [1, i]),
				System.Convert.ToInt32 (source [2, i]),
				System.Convert.ToInt32 (source [3, i]),
				System.Convert.ToInt32 (source [4, i]),
				//meta
				GetIntValuesForDefinition (source, 6, i, System.Convert.ToInt32 (source [2, i])),
				GetIntValuesForDefinition (source, 7, i, System.Convert.ToInt32 (source [2, i])),
				GetIntValuesForDefinition (source, 8, i, System.Convert.ToInt32 (source [2, i])),
				GetIntValuesForDefinition (source, 9, i, System.Convert.ToInt32 (source [2, i])),
				//core
				GetIntValuesForDefinition (source, 10, i, System.Convert.ToInt32 (source [2, i])),
				GetIntValuesForDefinition (source, 11, i, System.Convert.ToInt32 (source [2, i])),
				GetIntValuesForDefinition (source, 12, i, System.Convert.ToInt32 (source [2, i])),
				GetIntValuesForDefinition (source, 13, i, System.Convert.ToInt32 (source [2, i])),
				GetStringValuesForDefinition (source, 14, i, System.Convert.ToInt32 (source [2, i])));

			itemsDefs.Add (itemDef);
			if (source [2, i] != null)
				i = i + System.Convert.ToInt32 (source [2, i]) - 1;
			else
				break;
		}

		return itemsDefs;
	}

	static private int[] GetIntValuesForDefinition(string[,] source, int j, int i, int lenght)
	{
		int[] values = new int[lenght];
		for (int k = 0; k < lenght; k++) {
			int value = 0;
			if (source [j, i + k] != "")
				value = System.Convert.ToInt32 (source [j, i + k]);
			values [k] = value;
		}
		return values;
	}

	static private string[] GetStringValuesForDefinition(string[,] source, int j, int i, int lenght)
	{
		string[] values = new string[lenght];
		for (int k = 0; k < lenght; k++) {
			values [k] = source [j, i + k];
		}
		return values;
	}

	static public string[,] SplitCsvGrid(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]); 

		// finds the max width of row
		int width = 0; 
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine( lines[i] ); 
			width = Mathf.Max(width, row.Length); 
		}

		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1]; 
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine( lines[y] ); 
			for (int x = 0; x < row.Length; x++) 
			{
				outputGrid[x,y] = row[x]; 

				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x,y] = outputGrid[x,y].Replace("\"\"", "\"");
			}
		}

		return outputGrid; 
	}

	// splits a CSV row 
	static public string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
			@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
			System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
			select m.Groups[1].Value).ToArray();
	}

	// outputs the content of a 2D array, useful for checking the importer
	static public void DebugOutputGrid(string[,] grid)
	{
		string textOutput = ""; 
		for (int y = 0; y < grid.GetUpperBound(1); y++) {	
			for (int x = 0; x < grid.GetUpperBound(0); x++) {

				textOutput += grid[x,y]; 
				textOutput += "|"; 
			}
			textOutput += "\n"; 
		}
		Debug.Log(textOutput);
	}

	static public void DebugOutputItemDefinitions( List<ItemDefinition> itemDefs)
	{
		foreach (ItemDefinition itemDef in itemDefs) {
			Debug.Log ("-----------------------------");
			Debug.Log ("name: " + itemDef.name);
			Debug.Log ("type: " + itemDef.type.ToString());
			Debug.Log ("maxLevel: " + itemDef.maxLevel.ToString());
			Debug.Log ("league: " + itemDef.league.ToString());
			Debug.Log ("tier: " + itemDef.tier.ToString());
		}
		Debug.Log ("-----------------------------");
		Debug.Log ("Definition Count: " + itemDefs.Count);
	}
}
