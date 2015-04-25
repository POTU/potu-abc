using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseToggle : MonoBehaviour {

    GameObject PlayButton;
    Button UpButton;
    Button RightButton;

	// Use this for initialization
	void Start ()
    {
        PlayButton = transform.parent.Find("PlayButton").gameObject;
        UpButton = transform.parent.Find("UpButton").GetComponent<Button>();
        RightButton = transform.parent.Find("RightButton").GetComponent<Button>();
	}
	
    public void Pause(bool Pause)
    {
        if (Pause == true)
        {
            Time.timeScale = 0;
            PlayButton.SetActive(true);
            UpButton.interactable = false;
            RightButton.interactable = false;
        }
        else
        {
            Time.timeScale = 1;
            PlayButton.SetActive(false);
            UpButton.interactable = true;
            RightButton.interactable = true;
        }
    }
}
