using UnityEngine;
using System.Collections;

public static class CameraAdapter 
{
	//---------------------------------------------------------------------------------------------------
	//---------------------------------- Basic Camera operations ----------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Is the camera disabled?
	public static bool IsDisabled(Camera camera) {
		return (camera.enabled == false);
	}

	// Is the camera enabled?
	public static bool IsEnabled(Camera camera) {
		return (camera.enabled == true);
	}

	// Make the camera disabled
	public static void Disable(Camera camera) {
		camera.enabled = false;
	}

	// Make the camera enabled
	public static void Enable(Camera camera) {
		camera.enabled = true;
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------



	//---------------------------------------------------------------------------------------------------
	//----------------------------------- Array Camera operations ---------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Disable all cameras in an array
	public static void DisableAll(Camera[] cameras) {
		foreach (Camera camera in cameras)										// For each camera
			CameraAdapter.Disable(camera);										// Disable it
	}

	// Make only one camera in an array enabled (at specific index)
	public static void EnableOne(Camera[] cameras, int i) {
		CameraAdapter.DisableAll(cameras);										// Disable all cameras
		CameraAdapter.Enable(cameras[i]);										// Enable selected camera
	}

	// Switch to next camera in cycle manner
	public static void EnableNext(Camera[] cameras) {
		int nextShown = CameraAdapter.FindNext(cameras);						// Find which camera to enable next
		CameraAdapter.EnableOne(cameras, nextShown);							// Enable next camera
	}

	// Find currently enabled camera
	public static int FindEnabled(Camera[] cameras) {
		for (int i = 0; i < cameras.Length; i++)								// For each camera
			if (cameras[i].enabled)												// If the camera is enabled
				return i;														// Return index
		return -1;																// If enabled camera was not found, return -1
	}

	// Find next enabled camera
	public static int FindNext(Camera[] cameras) {
		int l = cameras.Length;
		int i = CameraAdapter.FindEnabled(cameras);

		if (i == l - 1)
			return 0;
		else if (i == -1)
			return 0;
		else 
			return i + 1;
	}


}
