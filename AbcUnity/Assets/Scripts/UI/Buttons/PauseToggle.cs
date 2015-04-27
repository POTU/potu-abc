using UnityEngine;
using UnityEngine.UI;
using Jalomieli.Extensions;

public class PauseToggle : MonoBehaviour {

    private GameObject PlayButton;
    private GameObject QuitButton;
	private Button UpButton;
	private Button RightButton;
	private CanvasGroup PauseButtonCanvasGroup;

    void Awake()
    {
        PlayButton = transform.parent.Find("PlayButton").gameObject;
        QuitButton = transform.parent.Find("QuitButton").gameObject;
        UpButton = transform.parent.Find("UpButton").GetComponent<Button>();
        RightButton = transform.parent.Find("RightButton").GetComponent<Button>();
        PauseButtonCanvasGroup = transform.parent.Find("PauseButton").GetComponent<CanvasGroup>();
    }
	
    public void Pause(bool Pause)
    {
		AudioSystem.Get().PlayUI();
        if (Pause)
        {
            Time.timeScale = 0;
            PlayButton.SetActive(true);
            QuitButton.SetActive(true);
            UpButton.interactable = false;
            RightButton.interactable = false;
			PauseButtonCanvasGroup.alpha = 0f;
        }
        else
        {
            Time.timeScale = 1;
            PlayButton.SetActive(false);
            QuitButton.SetActive(false);
            UpButton.interactable = true;
            RightButton.interactable = true;
			PauseButtonCanvasGroup.alpha = 1f;
        }
    }

    public void PauseToQuit()
    {
        // This shouldn't be here but I'm too lazy - Ruksi
        Time.timeScale = 1;
        PlayButton.SetActive(false);
        QuitButton.SetActive(false);
        UpButton.interactable = true;
        RightButton.interactable = true;
        PauseButtonCanvasGroup.alpha = 1f;
        AudioSystem.Get().PlayUI();
        Application.LoadLevel("StartScreen");
    }
}
