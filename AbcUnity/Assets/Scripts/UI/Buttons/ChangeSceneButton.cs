using UnityEngine;

public class ChangeSceneButton : MonoBehaviour 
{
	public void ChangeScene(int LevelNumber)
	{
        if (LevelNumber > 0)
        {
            PlayArea.LoadedLevel = LevelNumber;
            if (LevelNumber != 1)
            {
                AudioSystem.Get().PlayMusic(LevelNumber - 1);
            }
        }

		AudioSystem.Get().PlayUI();
        Application.LoadLevel("GameplayScreen");
	}

    public void LoadMenu()
    {
        if (PlayArea.LoadedLevel != 1)
        {
            AudioSystem.Get().PlayMusic(0);
        }
        Application.LoadLevel("StartScreen");
    }
}
