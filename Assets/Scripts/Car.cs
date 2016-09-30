using UnityEngine;
using System.Collections;
using System.IO;

public class Car : MonoBehaviour 
{	
	public Component bumperFront;
	public Component bumperRear;
	public Component exhaust;
	public Component sideskirt;
	public Component bonnet;
	public Component boot;
	public Component roof;
	public Component spoiler;
	public Component mirrors;
	public Component windows;

	private Component[] allComponents;

	public string carName;

	public CarColor carColor;


	// Use this for initialization
	void Start () {
		this.carColor.Initialize();
		this.InitializeAllComponents();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Initialization of all car components
	private void InitializeAllComponents() {
		allComponents = new Component[]{bumperFront, bumperRear, exhaust, sideskirt, bonnet, boot, roof, spoiler, mirrors, windows};
		foreach(Component c in allComponents)
			c.Initialize();
	}

	public int[] GetAllShownIndexes() {
		int[] indexes = new int[allComponents.Length];
		for (int i = 0; i < allComponents.Length; i++)
			indexes[i] = allComponents[i].GetShownIndex();
		return indexes;
	}

	public int GetColorIndex() {
		return carColor.GetShownIndex();
	}

	public void SetAllShownIndexes(int[] indexes) {
		for (int i = 0; i < allComponents.Length; i++)
			allComponents[i].SetShownIndex(indexes[i]);
	}

	public void SetColorIndex(int i) {
		Debug.Log("Car.SetColorIndex: i=" + i);
		carColor.SetShownIndex(i);
	}

	public void Save() {
		DataAdapter.SaveFile(this);
	}

	public void Load() {
		DataAdapter.LoadFile(this);
	}
}
