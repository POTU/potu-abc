using UnityEngine;
using UnityEngine.EventSystems;

public interface IScreenUILoadEventHandler : IEventSystemHandler
{
	void OnLoad(GameObject uiRootGo);
	void OnDestroy();
}
