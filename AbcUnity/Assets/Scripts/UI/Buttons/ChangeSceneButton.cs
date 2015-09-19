using UnityEngine;

public class ChangeSceneButton : MonoBehaviour 
{
	public void ChangeScene(int LevelNumber)
	{
        if (LevelNumber > 0)
        {
            PlayArea.LoadedLevel = LevelNumber;
        }
		AudioSystem.Get().PlayUI();
        Application.LoadLevel("GameplayScreen");
	}
}
