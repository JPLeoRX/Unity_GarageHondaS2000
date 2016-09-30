using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// An adapter class, with only static methods
// Helps in dealing with Part class

public static class PartAdapter  
{
	//---------------------------------------------------------------------------------------------------
	//------------------------------------ Basic Part operations ----------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Is the part invisible?
	public static bool IsHidden(Part part) {
		return MeshRendererAdapter.IsHidden(part.partMesh);
	}

	// Is the part visible?
	public static bool IsShown(Part part) {
		return MeshRendererAdapter.IsShown(part.partMesh);
	}

	// Make the part invisible
	public static void Hide(Part part) {
		MeshRendererAdapter.Hide(part.partMesh);
	}

	// Make the part visible
	public static void Show(Part part) {
		MeshRendererAdapter.Show(part.partMesh);
	}

	// Toggle the part visibility
	public static void Toggle(Part part) {
		if (PartAdapter.IsHidden(part))
			PartAdapter.Show(part);
		else if (PartAdapter.IsShown(part))
			PartAdapter.Hide(part);
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//------------------------------------ Array Part operations ----------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Make all the parts in an array invisible
	public static void HideAll(Part[] parts) {
		foreach (Part part in parts)										// For each part
			PartAdapter.Hide(part);											// Hide it
	}

	// Make only one part in an array visible (at specific index)
	public static void ShowOne(Part[] parts, int i) {
		PartAdapter.HideAll(parts);											// Hide all parts
		PartAdapter.Show(parts[i]);											// Show selected part
	}

	// Make only one part in an array visible (from specific dropdown)
	public static void ShowOne(Part[] parts, Dropdown dropdown) {
		PartAdapter.ShowOne(parts, dropdown.value);							// Show part at current dropdown selection
	}

	// Make only one part in an array visible (only "stock" part)
	public static void ShowOEM(Part[] parts) {
		PartAdapter.ShowOne(parts, PartAdapter.FindOEM(parts));				// Show OEM part
	}

	// Find index of OEM part in an array (1st occurance)
	public static int FindOEM(Part[] parts) {
		for (int i = 0; i < parts.Length; i++)								// For each part
			if (parts[i].isOEM)												// If it is OEM
				return i;													// Return index
		return -1;															// If no OEM parts found, return -1
	}

	// Find index of a visible part in an array (1st occurance)
	public static int FindShown(Part[] parts) {
		for (int i = 0; i < parts.Length; i++)								// For each part
			if (PartAdapter.IsShown(parts[i]))								// If it is visible
				return i;													// Return index
		return -1;															// If no visible parts found, return -1
	}

	// Get names from parts array as a string array
	public static string[] GetNames(Part[] parts) {
		string[] names = new string[parts.Length];							// Create new string array
		for (int i = 0; i < parts.Length; i++)								// For each part
			names[i] = parts[i].partName;									// Save name to array
		return names;														// Return array
	}

	// Fill dropdown based on parts array
	public static void FillDropdown(Part[] parts, Dropdown dropdown) {
		dropdown.options.Clear();											// Clear previous options
		string[] names = PartAdapter.GetNames(parts);						// Get array of names
		dropdown.captionText.text = names[0];								// Set caption
		foreach (string name in names)										// For each name
			dropdown.options.Add(new Dropdown.OptionData(name));			// Add it to the dropdown options
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
}