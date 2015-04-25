using UnityEngine;
using UnityEngine.UI;
using Unity.Linq;
using Jalomieli.Debug;
using Jalomieli.Extensions;
using DG.Tweening;

public class SubUIMaster : MonoBehaviour 
{
	public GameObject startScreenSubUI;	
	public GameObject gameplayScreenSubUI;
	private Sequence startScreenSubUISequence;
	void OnDestroy() {
		Log.Warning("SubUIMaster should be destroyed ONLY on exit.");
	}
	public void ShowStartScreenSubUI() 
	{
		Log.Info("+++ Start Sub UI");
		if (startScreenSubUISequence != null && startScreenSubUISequence.IsPlaying()) {
			startScreenSubUISequence.Complete();
		}
		
		var group = startScreenSubUI.DemandComponent<CanvasGroup>();
		group.interactable = true;
		
		startScreenSubUISequence = DOTween.Sequence();
		startScreenSubUISequence.Append(DOTween.To(
			() => group.alpha,
			x => group.alpha = x,
			1f,
			0.5f
		));
		startScreenSubUISequence.OnComplete(() => {
			group.alpha = 1f;
		});
		
		startScreenSubUI.SetActive(true);
	}
	public void HideStartScreenSubUI() 
	{
		Log.Info("--- Start Sub UI");
		if (startScreenSubUISequence != null && startScreenSubUISequence.IsPlaying()) {
			startScreenSubUISequence.Complete();
		}
		
		var group = startScreenSubUI.DemandComponent<CanvasGroup>();
		group.interactable = false;
		
		startScreenSubUISequence = DOTween.Sequence();
		startScreenSubUISequence.Append(DOTween.To(
			() => group.alpha,
			x => group.alpha = x,
			0f,
			0.5f
			));
		startScreenSubUISequence.OnComplete(() => {
			group.alpha = 0f;
			startScreenSubUI.SetActive(false);
		});
		
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
