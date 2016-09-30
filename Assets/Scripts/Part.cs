using UnityEngine;
using System.Collections;

// A class that represent one 3D part of a car
// It can be a bonnet, a bumper, a muffler, whatever we need
//
// It is a single part, with a specific 3D mesh used as a MeshRenderer object
// It also has a name, which should be the manufacture's company name
// And a flag that indicates that this part belongs to stock (not modified) car appearence

[System.Serializable]
public class Part 
{
	public MeshRenderer partMesh;					// 3D mesh of this part
	public string partName;							// name of this particular part, usually same as manufacture's name
	public bool isOEM;								// is this an OEM part? Should it be shown as a "stock" version?
}