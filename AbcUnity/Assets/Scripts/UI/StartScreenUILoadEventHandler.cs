using UnityEngine;
using Jalomieli.Extensions;

public class StartScreenUILoadEventHandler : MonoBehaviour, IScreenUILoadEventHandler 
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
		master.ShowStartScreenSubUI();
	}
	public void OnUnload()
	{
		if (this.uiRootGo == null) { return; }
		var master = this.uiRootGo.DemandComponent<SubUIMaster>();
		master.HideStartScreenSubUI();
	}
}
