using UnityEngine;

public class ChangeSceneButton : MonoBehaviour 
{
	public void ChangeScene(string sceneName)
	{
		AudioSystem.Get().PlayUI();
		Application.LoadLevel(sceneName);
	}
}
