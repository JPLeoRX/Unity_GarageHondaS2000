using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraOrbit : MonoBehaviour 
{
	public Transform target;

	public float distance = 3.3f;							// Distance to target object
	public float yMinLimit = 10f;							// Minimum Y coordinate
	public float yMaxLimit = 60f;							// Maximum Y coordinate

	public float xSpeedPC = 120.0f;							// Speed of camera rotation in X direction for PC
	public float ySpeedPC = 120.0f;							// Speed of camera rotation in Y direction for PC

	public float xSpeedPhone = 20.0f;						// Speed of camera rotation in X direction for Phone
	public float ySpeedPhone = 20.0f;						// Speed of camera rotation in Y direction for Phone

	private float x = 0.0f;
	private float y = 0.0f;
	private bool isFirst = true;

	void Start () 
	{
		Vector3 angles = this.transform.eulerAngles;
		this.x = angles.y;
		this.y = angles.x;
	}

	void LateUpdate () 
	{
		if (Application.platform == RuntimePlatform.WindowsEditor)
			this.RotatePC();

		else if (Application.platform == RuntimePlatform.WindowsPlayer)
			this.RotatePC();
		
		else if (Application.platform == RuntimePlatform.Android)
			this.RotatePhone();
	}

	private void RotatePC()
	{
		if (this.target != null)
		{
			if (Input.GetMouseButton(0) || isFirst) 
			{
				// Compute new X, Y coordinates
				this.x += Input.GetAxis("Mouse X") * xSpeedPC * distance * 0.02f;
				this.y -= Input.GetAxis("Mouse Y") * ySpeedPC * 0.02f;

				// Clamp Y coordinate between min and max values
				this.y = ClampAngle(y, yMinLimit, yMaxLimit);

				// Compute new rotation and position
				Quaternion rotation = Quaternion.Euler(y, x, 0);
				Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
				Vector3 position = rotation * negDistance + target.position;

				// Apply new rotation and position
				this.transform.rotation = rotation;
				this.transform.position = position;

				if (isFirst)
					isFirst = false;
			}
		}
	}

	private void RotatePhone()
	{
		if (this.target != null)
		{
			if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || isFirst) 
			{
				// Compute new X, Y coordinates
				Vector2 delta = Input.GetTouch(0).deltaPosition;
				this.x += delta.x * xSpeedPhone * distance * 0.02f;
				this.y -= delta.y * ySpeedPhone * 0.02f;

				// Clamp Y coordinate between min and max values
				this.y = ClampAngle(y, yMinLimit, yMaxLimit);

				// Compute new rotation and position
				Quaternion rotation = Quaternion.Euler(y, x, 0);
				Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
				Vector3 position = rotation * negDistance + target.position;

				// Apply new rotation and position
				this.transform.rotation = rotation;
				this.transform.position = position;

				if (isFirst)
					isFirst = false;
			}
		}
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	public void Enable()
	{
		enabled = true;
	}

	public void Disable()
	{
		enabled = false;
	}

	public void Toggle()
	{
		if (enabled)
			enabled = false;
		else
			enabled = true;
	}
}