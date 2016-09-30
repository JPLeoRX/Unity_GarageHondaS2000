using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class CarColor 
{
	public Dropdown dropdown;
	public Material carPaint;
	private Texture[] colorTextures;

	private static readonly string path = "Car Colors";

	public void Initialize () {
		this.colorTextures = ColorAdapter.GetTextures(path);						// Read all color textures
		ColorAdapter.FillDropdown(this.colorTextures, this.dropdown);				// Fill the dropdown with textures
		this.InitializeDropdownListener();											// Initialize listener
		this.OnDropdownChange();													// Reset current color
	}

	// Attach a listener to the dropdown
	private void InitializeDropdownListener() {
		dropdown.onValueChanged.AddListener(delegate {
			OnDropdownChange();
		});
	}

	// What happens when dropdown value is changed?
	public void OnDropdownChange() {
		carPaint.mainTexture = colorTextures[dropdown.value];						// Set new color texture
	}

	public int GetShownIndex() {
		for (int i = 0; i < colorTextures.Length; i++)
			if (carPaint.mainTexture.name.Equals(colorTextures[i].name))
				return i;
		return -1;
	}

	public void SetShownIndex(int i) {
		carPaint.mainTexture = colorTextures[i];									// Set new color texture
		dropdown.value = i;															// Set new dropdown value
	}
}
