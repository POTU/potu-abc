using UnityEngine;
using Jalomieli.Debug;

public class SubUIMaster : MonoBehaviour 
{
	public GameObject startScreenSubUI;	
	public GameObject gameplayScreenSubUI;
	void OnDestroy() {
		Log.Warning("SubUIMaster should be destroyed ONLY on exit.");
	}
	public void ShowStartScreenSubUI() 
	{
		Log.Info("+++ Start Sub UI");
		startScreenSubUI.SetActive(true);
	}
	public void HideStartScreenSubUI() 
	{
		Log.Info("--- Start Sub UI");
		startScreenSubUI.SetActive(false);
	}
	public void ShowGameplayScreenSubUI() 
	{
		Log.Info("+++ Gameplay Sub UI");
		gameplayScreenSubUI.SetActive(true);
	}
	public void HideGameplayScreenSubUI() 
	{
		Log.Info("--- Gameplay Sub UI");
		gameplayScreenSubUI.SetActive(false);
	}
}
