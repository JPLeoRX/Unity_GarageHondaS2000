using UnityEngine;
using System.Collections;

public static class MeshRendererAdapter 
{
	//---------------------------------------------------------------------------------------------------
	//------------------------------- Basic MeshRenderer operations -------------------------------------
	//---------------------------------------------------------------------------------------------------
	// Is the mesh invisible?
	public static bool IsHidden(MeshRenderer mesh) {
		return (mesh.enabled == false);
	}

	// Is the mesh visible?
	public static bool IsShown(MeshRenderer mesh) {
		return (mesh.enabled == true);
	}

	// Make the mesh invisible
	public static void Hide(MeshRenderer mesh) {
		mesh.enabled = false;
	}

	// Make the mesh visible
	public static void Show(MeshRenderer mesh) {
		mesh.enabled = true;
	}

	// Toggle the mesh visibility
	public static void Toggle(MeshRenderer mesh) {
		if (MeshRendererAdapter.IsHidden(mesh))
			MeshRendererAdapter.Show(mesh);
		else if (MeshRendererAdapter.IsShown(mesh))
			MeshRendererAdapter.Hide(mesh);
	}
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
	//---------------------------------------------------------------------------------------------------
}