using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour 
{
	public Canvas canvasMain;								// Main menu canvas
	public Canvas canvasAbout;								// About menu canvas
	public Canvas canvasLevels;								// Levels meny canvas

	//---------------------------------------------------------------------------------------------------
	//--------------------------------------- Game mechanics --------------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () {
		// Hide all except main menu
		MenuAdapter.Show(canvasMain); MenuAdapter.Hide(canvasAbout); MenuAdapter.Hide(canvasLevels);
	}
	
	// Update is called once per frame
	void Update () {
		if (MenuAdapter.IsBackKeyPressed()) {
			if (MenuAdapter.IsShown(canvasMain))
				this.OnExitGame();
			else if (MenuAdapter.IsShown(canvasAbout))
				this.OnExitAbout();
			else if (MenuAdapter.IsShown(canvasLevels))
				this.OnExitPlay();
		}
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//-------------------------------------- Button responses -------------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Response to click on Exit button (while in the main menu)
	public void OnExitGame() {
		// Kill the game
		Application.Quit();
	}

	// Response to click on Exit button (while in the about menu)
	public void OnExitAbout() {
		// Hide all except main menu
		MenuAdapter.Show(canvasMain); MenuAdapter.Hide(canvasAbout); MenuAdapter.Hide(canvasLevels);
	}

	// Response to click on Exit button (while in the play menu)
	public void OnExitPlay() {
		// Hide all except main menu
		MenuAdapter.Show(canvasMain); MenuAdapter.Hide(canvasAbout); MenuAdapter.Hide(canvasLevels);
	}

	// Response to click on About button (while in the main menu)
	public void OnAbout() {
		// Hide all except about menu
		MenuAdapter.Hide(canvasMain); MenuAdapter.Show(canvasAbout); MenuAdapter.Hide(canvasLevels);
	}

	// Response to click on Play button (while in the main menu)
	public void OnPlay() {
		// Hide all except levels menu
		MenuAdapter.Hide(canvasMain); MenuAdapter.Hide(canvasAbout); MenuAdapter.Show(canvasLevels);
	}



	public void OnLevel_HONDA_S2000() {
		SceneManager.LoadSceneAsync("honda_s2000");
	}

	public void OnLevel_HONDA_NSX() {
		SceneManager.LoadSceneAsync("honda_nsx");
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
}