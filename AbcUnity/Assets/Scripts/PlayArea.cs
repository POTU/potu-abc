using UnityEngine;
using UnityEngine.EventSystems;
using Jalomieli.Debug;
using Jalomieli.Extensions;
using System.Collections;
using System.Linq;

public class PlayArea : MonoBehaviour 
{
    public static int LoadedLevel = 1;

	private int lastWidth;
	private int lastHeight;

    public SpriteRenderer BGRenderer;
    public SpriteRenderer BottomBarRenderer;

    public Sprite Level1BG;
    public Sprite Level1BottomBar;

    public Sprite Level2BG;
    public Sprite Level2BottomBar;

    public Sprite Level3BG;
    public Sprite Level3BottomBar;

    public GameObject EnemySpawn1;
    public GameObject EnemySpawn2;
    public GameObject EnemySpawn3;

    public static PlayArea thisArea;


    void Awake()
    {
        thisArea = this;
        GameObject EnemySpawner = null;
        switch (LoadedLevel)
        {
            case 1:
                EnemySpawner = EnemySpawn1.CreateAsChild(gameObject.transform.parent);
                EnemySpawner.transform.localPosition = new Vector2(10, 0);
                BGRenderer.sprite = Level1BG;
                BottomBarRenderer.sprite = Level1BottomBar;
                break;

            case 2:
                EnemySpawner = EnemySpawn2.CreateAsChild(gameObject.transform.parent);
                EnemySpawner.transform.position = new Vector3(10, 0, 0);
                BGRenderer.sprite = Level2BG;
                BottomBarRenderer.sprite = Level2BottomBar;
                break;

            case 3:
                EnemySpawner = EnemySpawn3.CreateAsChild(gameObject.transform.parent);
                EnemySpawner.transform.localPosition = new Vector3(10, 0, 0);
                BGRenderer.sprite = Level3BG;
                BottomBarRenderer.sprite = Level3BottomBar;
                break;
        }

        PlayerController.thisController.SetSprite(LoadedLevel);
    }

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
			other.gameObject.transform.parent.gameObject, 
			null, 
			(x, y) => x.OnDeath()
		);
	}

    public void ShowEnd()
    {
        StartCoroutine(EndScreen());
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(2f);
        var go = GameObject.FindGameObjectsWithTag("MainUIRoot").FirstOrDefault();
        var master = go.GetComponent<SubUIMaster>();

        master.ShowEndScreenSubUI();
    }
}
