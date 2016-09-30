using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevel : MonoBehaviour 
{
	public Canvas partsMenu;							// Parts menu canvas
	public Canvas colorsMenu;							// Colors menu canvas
	public CameraOrbit freeCamera;						// Camera

	//---------------------------------------------------------------------------------------------------
	//--------------------------------------- Game mechanics --------------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () {
		MenuAdapter.Hide(partsMenu);
		MenuAdapter.Hide(colorsMenu);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (MenuAdapter.IsBackKeyPressed())
		{
			if (MenuAdapter.IsShown(partsMenu)) {
				MenuAdapter.Hide(partsMenu);
				freeCamera.Enable();
			}

			else if (MenuAdapter.IsShown(colorsMenu)) {
				MenuAdapter.Hide(colorsMenu);
				freeCamera.Enable();
			}

			else {
				this.OnExitLevel();
			}
		}
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//-------------------------------------- Button responses -------------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Response to click on Parts button (while in the level)
	public void OnButtonParts() 
	{
		if (MenuAdapter.IsShown(partsMenu))
		{
			MenuAdapter.Hide(partsMenu);
			MenuAdapter.Hide(colorsMenu);
			freeCamera.Enable();
		}

		else if (MenuAdapter.IsShown(colorsMenu))
		{
			MenuAdapter.Show(partsMenu);
			MenuAdapter.Hide(colorsMenu);
			freeCamera.Disable();
		}

		else
		{
			MenuAdapter.Show(partsMenu);
			MenuAdapter.Hide(colorsMenu);
			freeCamera.Disable();
		}
	}

	// Response to click on Colors button (while in the level)
	public void OnButtonColors() 
	{
		if (MenuAdapter.IsShown(partsMenu))
		{
			MenuAdapter.Hide(partsMenu);
			MenuAdapter.Show(colorsMenu);
			freeCamera.Disable();
		}

		else if (MenuAdapter.IsShown(colorsMenu))
		{
			MenuAdapter.Hide(partsMenu);
			MenuAdapter.Hide(colorsMenu);
			freeCamera.Enable();
		}

		else
		{
			MenuAdapter.Hide(partsMenu);
			MenuAdapter.Show(colorsMenu);
			freeCamera.Disable();
		}
	}

	// Response to click on Exit button (while in the level)
	public void OnExitLevel() {
		MenuAdapter.Hide(partsMenu);
		MenuAdapter.Hide(colorsMenu);
		SceneManager.LoadSceneAsync("menu");
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
}