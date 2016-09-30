using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Data 
{
	private int[] selectedIndexes;									// Indexes of currently selected parts of components
	private int colorIndex;

	// Get selected indexes
	public int[] GetSelectedIndexes() {
		int[] newIndexes = new int[selectedIndexes.Length];			// Create new array
		for (int i = 0; i < selectedIndexes.Length; i++)			// For each index
			newIndexes[i] = selectedIndexes[i];						// Save index to new array
		return newIndexes;											// Return new array
	}

	public int GetColorIndex() {
		return colorIndex;
	}

	// Set selected indexes
	public void SetSelectedIndexes(int[] newIndexes) {
		selectedIndexes = new int[newIndexes.Length];				// Reset array
		for (int i = 0; i < newIndexes.Length; i++)					// For each index
			selectedIndexes[i] = newIndexes[i];						// Save index to array
	}

	public void SetColorIndex(int i) {
		Debug.Log("Data.SetColorIndex: i=" + i);
		colorIndex = i;
	}

	// Save this data to a file
	public void SaveToFile(string filePath) {
		BinaryFormatter b = new BinaryFormatter();					// Open binary formatter
		FileStream f = File.Create(filePath);						// Create new file stream
		b.Serialize(f, this);										// Serialize data in file
		f.Close();													// Close file
	}

	// Load data from file to this
	public void LoadFromFile(string filePath) {
		if (File.Exists(filePath))									// If file exists
		{
			Debug.Log("Data.LoadFromFile");
			BinaryFormatter b = new BinaryFormatter();				// Open binary formatter
			FileStream f = File.Open(filePath, FileMode.Open);		// Open existing file stream
			Data d = (Data) b.Deserialize(f);						// Deserialize data from file
			f.Close();												// Close file
			this.SetSelectedIndexes(d.GetSelectedIndexes());		// Save loaded data to this object
			this.SetColorIndex(d.GetColorIndex());					// Save loaded color to this object
		}
	}
}
