using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElementScaler : MonoBehaviour {

	float ReferenceHeight;
	float CurrentHeight;
	float HeightRatio;
	
	float ReferenceWidth;
	float CurrentWidth;
	float WidthRatio;

	// Use this for initialization
	void Start ()
	{
        CurrentHeight = Screen.height;		
        CurrentWidth = Screen.width;

        float CurrentRatio = CurrentWidth / CurrentHeight;

        print(CurrentRatio);

        float ReferenceRatio = 2048f / 1536f;

        print(ReferenceRatio);

        float DifferenceRatio = CurrentRatio / ReferenceRatio;

        transform.localScale = new Vector2(transform.localScale.x * DifferenceRatio, transform.localScale.y);
        print(DifferenceRatio);
    }
}