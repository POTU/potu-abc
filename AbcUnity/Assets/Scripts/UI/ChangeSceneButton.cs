using UnityEngine;

public class ChangeSceneButton : MonoBehaviour 
{
	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}
