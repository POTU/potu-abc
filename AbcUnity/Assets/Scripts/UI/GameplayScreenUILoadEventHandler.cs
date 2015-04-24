using UnityEngine;
using Jalomieli.Extensions;

public class GameplayScreenUILoadEventHandler : MonoBehaviour, IScreenUILoadEventHandler 
{
	private GameObject uiRootGo;
	
	public void OnLoad(GameObject uiRootGo)
	{
		this.uiRootGo = uiRootGo;
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.ShowGameplayScreenSubUI();
	}
	
	public void OnDestroy()
	{
		if (this.uiRootGo == null) { return; }
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.HideGameplayScreenSubUI();
	}
}
