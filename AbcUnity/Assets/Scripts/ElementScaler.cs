using UnityEngine;

public class ElementScaler : MonoBehaviour {

	float ReferenceHeight;
	float CurrentHeight;
	float HeightRatio;
	
	float ReferenceWidth;
	float CurrentWidth;
	float WidthRatio;

	void Start ()
	{
        CurrentHeight = Screen.height;		
        CurrentWidth = Screen.width;
        float CurrentRatio = CurrentWidth / CurrentHeight;
        float ReferenceRatio = 2048f / 1536f;
        float DifferenceRatio = CurrentRatio / ReferenceRatio;
        transform.localScale = new Vector2(transform.localScale.x * DifferenceRatio, transform.localScale.y);
    }
}