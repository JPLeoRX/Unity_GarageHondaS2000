using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A class that represent a collection of same type of 3D parts for a car
// It can be a set (stock and tuned, all versions) of bonnets, bumpers, mufflers, whatever we need
//
// It is a set of multiple parts, with parts specified as an array. One of the parts must be "stock" (have isOEM flag).
// It has a corresponding UI element, a dropdown. Dropdown is filled from parts array, and a listener is attached to it.

[System.Serializable]
public class Component 
{
	public Dropdown dropdown;										// dropdown 
	public Part[] parts;											// array of parts

	// What happens when this object is initialized?
	public void Initialize() {
		PartAdapter.FillDropdown(parts, dropdown);					// Setup the dropdown from parts array
		PartAdapter.ShowOEM(parts);									// Show only OEM part initially
		this.InitializeDropdownListener();							// Set listener to dropdown
	}

	// Attach a listener to the dropdown
	private void InitializeDropdownListener() {
		dropdown.onValueChanged.AddListener(delegate {
			OnDropdownChange();
		});
	}
		
	// What happens when dropdown value is changed?
	public void OnDropdownChange() {
		PartAdapter.ShowOne(parts, dropdown);						// Show dropdown selection
	}

	public int GetShownIndex() {
		return PartAdapter.FindShown(parts);
	}

	public void SetShownIndex(int i) {
		PartAdapter.ShowOne(parts, i);
		dropdown.value = i;
	}
}