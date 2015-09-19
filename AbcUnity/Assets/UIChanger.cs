using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIChanger : MonoBehaviour {

    public List<Sprite> UpButtonImages = new List<Sprite>();
    public List<Sprite> RightButtonImages = new List<Sprite>();
    //public List<Sprite> PauseButtonImages = new List<Sprite>();

    public Image UpButtonImage;
    public Image RightButtonImage;
    //public Image PauseButtonImage;


	// Use this for initialization
	void Start () 
    {
        UpButtonImage.sprite = UpButtonImages[PlayArea.LoadedLevel - 1];
        RightButtonImage.sprite = RightButtonImages[PlayArea.LoadedLevel - 1];
	}
}
