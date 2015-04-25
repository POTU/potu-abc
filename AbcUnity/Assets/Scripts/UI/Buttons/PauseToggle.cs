using UnityEngine;
using UnityEngine.UI;
using Jalomieli.Extensions;

public class PauseToggle : MonoBehaviour {

    private GameObject PlayButton;
	private Button UpButton;
	private Button RightButton;
	private CanvasGroup PauseButtonCanvasGroup;

	void Start ()
    {
        PlayButton = transform.parent.Find("PlayButton").gameObject;
        UpButton = transform.parent.Find("UpButton").GetComponent<Button>();
        RightButton = transform.parent.Find("RightButton").GetComponent<Button>();
		PauseButtonCanvasGroup = transform.parent.Find("PauseButton").GetComponent<CanvasGroup>();
	}
	
    public void Pause(bool Pause)
    {
        if (Pause)
        {
            Time.timeScale = 0;
            PlayButton.SetActive(true);
            UpButton.interactable = false;
            RightButton.interactable = false;
			PauseButtonCanvasGroup.alpha = 0f;
        }
        else
        {
            Time.timeScale = 1;
            PlayButton.SetActive(false);
            UpButton.interactable = true;
            RightButton.interactable = true;
			PauseButtonCanvasGroup.alpha = 1f;
        }
    }
}
