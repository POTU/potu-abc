using UnityEngine;
using Jalomieli.Extensions;

public class AudioSourceAutoDestroy : MonoBehaviour 
{
	private AudioSource audioSource;	
	public void Start() 
	{
		audioSource = this.gameObject.DemandComponent<AudioSource>();
	}
	public void Update() 
	{
		if (audioSource)
		{
			if (!audioSource.isPlaying)
			{
				Destroy(gameObject);
			}
		}
	}
}
