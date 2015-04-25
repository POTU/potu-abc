using UnityEngine;
using Jalomieli.Debug;
using Jalomieli.Extensions;
using DG.Tweening;

public class SubUIMaster : MonoBehaviour 
{
	public GameObject startScreenSubUI;	
	public GameObject gameplayScreenSubUI;
	public GameObject endScreenSubUI;
	private Sequence startScreenSubUISequence;
	private Sequence gameplayScreenSubUISequence;
	private Sequence endScreenSubUISequence;
	public bool IsStartScreenSubUIShow { get; private set; }
	public bool IsGameplayScreenSubUIShow { get; private set; }
	public bool IsEndScreenSubUIShow { get; private set; }
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
		IsStartScreenSubUIShow = true;
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
		IsStartScreenSubUIShow = false;
	}
	public void ShowGameplayScreenSubUI() 
	{
		Log.Info("+++ Gameplay Sub UI");
		if (gameplayScreenSubUISequence != null && gameplayScreenSubUISequence.IsPlaying()) {
			gameplayScreenSubUISequence.Complete();
		}
		
		var group = gameplayScreenSubUI.DemandComponent<CanvasGroup>();
		group.interactable = true;
		
		gameplayScreenSubUISequence = DOTween.Sequence();
		gameplayScreenSubUISequence.Append(DOTween.To(
			() => group.alpha,
			x => group.alpha = x,
			1f,
			2f
		));
		
		gameplayScreenSubUI.SetActive(true);
		IsGameplayScreenSubUIShow = true;
	}
	public void HideGameplayScreenSubUI() 
	{
		Log.Info("--- Gameplay Sub UI");
		if (gameplayScreenSubUISequence != null && gameplayScreenSubUISequence.IsPlaying()) {
			gameplayScreenSubUISequence.Complete();
		}
		
		gameplayScreenSubUI.SetActive(false);
		IsGameplayScreenSubUIShow = false;
	}
	public void ShowEndScreenSubUI() 
	{
		Log.Info("+++ End Sub UI");		
		endScreenSubUI.SetActive(true);
		IsEndScreenSubUIShow = true;
	}
	public void HideEndScreenSubUI() 
	{
		Log.Info("--- End Sub UI");
		endScreenSubUI.SetActive(false);
		IsEndScreenSubUIShow = false;
	}
}
