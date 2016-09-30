using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataAdapter
{
	public static void GetFromCar(Car car, Data data) {
		data.SetSelectedIndexes(car.GetAllShownIndexes());
		data.SetColorIndex(car.GetColorIndex());
	}

	public static void SetToCar(Car car, Data data) {
		Debug.Log("DataAdapter.SetToCar");
		car.SetColorIndex(data.GetColorIndex());
		car.SetAllShownIndexes(data.GetSelectedIndexes());
	}

	public static void SaveFile(Car car) 
	{
		string path = Application.persistentDataPath + "/" + car.carName + ".n";
		Data data = new Data();
		DataAdapter.GetFromCar(car, data);
		data.SaveToFile(path);
	}

	public static void LoadFile(Car car)
	{
		Debug.Log("DataAdapter.LoadFile");
		string path = Application.persistentDataPath + "/" + car.carName + ".n";
		Data data = new Data();
		data.LoadFromFile(path);
		DataAdapter.SetToCar(car, data);
	}
}
