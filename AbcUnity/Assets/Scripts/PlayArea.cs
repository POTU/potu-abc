using UnityEngine;
using UnityEngine.EventSystems;
using Jalomieli.Debug;
using Jalomieli.Extensions;

public class PlayArea : MonoBehaviour 
{
	private int lastWidth;
	private int lastHeight;
	void Update()
	{
		var hasChanged = (lastWidth != Camera.main.pixelWidth || lastHeight != Camera.main.pixelHeight);
		if (hasChanged) 
		{
			float screenAspect = (float)Screen.width / (float)Screen.height;
			float cameraHeight = Camera.main.orthographicSize * 2;
			var col = this.gameObject.DemandComponent<BoxCollider2D>();
			col.size = new Vector2(cameraHeight * screenAspect, cameraHeight);
			Log.Info("Play area resized.");
		}
		lastWidth = Camera.main.pixelWidth;
		lastHeight = Camera.main.pixelHeight;
	}
	void OnTriggerExit2D(Collider2D other) 
	{
		ExecuteEvents.Execute<IDeathHandler>(
			other.gameObject, 
			null, 
			(x, y) => x.OnDeath()
		);
	}
}
