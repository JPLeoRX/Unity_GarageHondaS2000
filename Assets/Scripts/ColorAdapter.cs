using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public static class ColorAdapter  
{
	public static Texture[] GetTextures(string pathInResources)
	{
		Object[] obj = Resources.LoadAll(pathInResources, typeof(Texture));
		Texture[] tex = new Texture[obj.Length];

		for (int i = 0; i < obj.Length; i++)
			tex[i] = (Texture) obj[i];

		return tex;
	}

	public static string[] GetNames(Texture[] textures)
	{
		string[] names = new string[textures.Length];

		for (int i = 0; i < textures.Length; i++)
		{
			string temp = textures[i].name;
			int j = temp.IndexOf("-") + 2;
			temp = temp.Substring(j);
			names[i] = temp;
		}

		return names;
	}

	// Fill dropdown based on parts array
	public static void FillDropdown(Texture[] textures, Dropdown dropdown) {
		dropdown.options.Clear();											// Clear previous options
		string[] names = ColorAdapter.GetNames(textures);						// Get array of names
		dropdown.captionText.text = names[0];								// Set caption
		foreach (string name in names)										// For each name
			dropdown.options.Add(new Dropdown.OptionData(name));			// Add it to the dropdown options
	}


}
