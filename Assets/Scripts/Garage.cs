using UnityEngine;
using System.Collections;

public class Garage : MonoBehaviour {

	public Camera[] cameras;

	// Use this for initialization
	void Start () {
		CameraAdapter.EnableOne(cameras, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeCamera() {
		CameraAdapter.EnableNext(cameras);
	}
}
