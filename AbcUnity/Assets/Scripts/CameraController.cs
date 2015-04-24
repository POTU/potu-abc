using UnityEngine;

public class CameraController : MonoBehaviour 
{
	void Update () 
	{
		transform.Translate(new Vector3(3f, 0f, 0f) * Time.deltaTime);
	}
}
