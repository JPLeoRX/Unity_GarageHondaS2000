using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class MenuAdapter 
{
	//---------------------------------------------------------------------------------------------------
	//------------------------------- Basic Menu related operations -------------------------------------
	//---------------------------------------------------------------------------------------------------
	public static bool IsShown(Canvas c) {
		return (c.enabled == true);
	}

	public static bool IsHidden(Canvas c) {
		return (c.enabled == false);
	}

	public static void Show(Canvas c) {
		c.enabled = true;
	}

	public static void Hide(Canvas c) {
		c.enabled = false;
	}

	public static void Toggle(Canvas c) {
		if (MenuAdapter.IsHidden(c))
			MenuAdapter.Show(c);
		else if (MenuAdapter.IsShown(c))
			MenuAdapter.Hide(c);
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//---------------------------------- Platfrom identification ----------------------------------------
	//---------------------------------------------------------------------------------------------------
	public static bool IsAndroid() {
		return (Application.platform == RuntimePlatform.Android);
	}

	public static bool IsIPhone() {
		return (Application.platform == RuntimePlatform.IPhonePlayer);
	}

	public static bool IsWindows() {
		return (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor);
	}

	public static bool IsOSX() {
		return (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor);
	}

	public static bool IsLinux() {
		return (Application.platform == RuntimePlatform.LinuxPlayer);
	}

	public static bool IsPC() {
		return (MenuAdapter.IsWindows() || MenuAdapter.IsOSX() || MenuAdapter.IsLinux());
	}

	public static bool IsSmartphone() {
		return (MenuAdapter.IsAndroid() || MenuAdapter.IsIPhone());
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//--------------------------------- Game state identification ---------------------------------------
	//---------------------------------------------------------------------------------------------------
	public static bool IsMenu() {
		return (SceneManager.GetActiveScene().name.Equals("menu"));
	}

	public static bool IsLevel() {
		return !MenuAdapter.IsMenu();
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//--------------------------------- Game input identification ---------------------------------------
	//---------------------------------------------------------------------------------------------------
	public static bool IsBackKeyPressed() {
		return (Input.GetKey(KeyCode.Escape));
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
}
