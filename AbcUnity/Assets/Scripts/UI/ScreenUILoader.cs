using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Jalomieli.Debug;

public class ScreenUILoader : MonoBehaviour 
{
	IEnumerator Start() {
		var uiRootGO = GetGameUIGameObject();
		if (uiRootGO == null) 
		{
			AsyncOperation async = Application.LoadLevelAdditiveAsync("MainUI");
			yield return async;
		}
		else 
		{
			yield return true;
		}
		uiRootGO = GetGameUIGameObject();
		Assert.NotNull(uiRootGO); 
		ExecuteEvents.Execute<IScreenUILoadEventHandler>(
			gameObject, 
			null, 
			(x, y) => x.OnLoad(uiRootGO)
		);
	}
	
	/// <summary>
	/// Gets the game user interface game object.
	/// </summary>
	/// <returns>Game UI game object or null</returns>
	private GameObject GetGameUIGameObject()
	{
		return GameObject.FindGameObjectsWithTag("MainUIRoot").FirstOrDefault();
	}
}
