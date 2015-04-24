using UnityEngine;
using Jalomieli.Extensions;

public class StartScreenUILoadEventHandler : MonoBehaviour, IScreenUILoadEventHandler 
{
	private GameObject uiRootGo;
	
	public void OnLoad(GameObject uiRootGo)
	{
		this.uiRootGo = uiRootGo;
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.ShowStartScreenSubUI();
	}
	
	public void OnDestroy()
	{
		if (this.uiRootGo == null) { return; }
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.HideStartScreenSubUI();
	}
}
