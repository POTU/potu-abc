using UnityEngine;
using Jalomieli.Extensions;

public class GameplayScreenUILoadEventHandler : MonoBehaviour, IScreenUILoadEventHandler 
{
	private GameObject uiRootGo;
	void OnDestroy() 
	{
		OnUnload();
	}
	public void OnLoad(GameObject uiRoot)
	{
		this.uiRootGo = uiRoot;
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.ShowGameplayScreenSubUI();
	}
	public void OnUnload()
	{
		if (this.uiRootGo == null) { return; }
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.HideGameplayScreenSubUI();
	}
}
