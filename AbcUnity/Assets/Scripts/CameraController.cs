using UnityEngine;

public class CameraController : MonoBehaviour 
{
	void Update () 
	{
		transform.Translate(new Vector3(2f, 0f, 0f) * Time.deltaTime);
	}
}
