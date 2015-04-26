using UnityEngine;
using Jalomieli.Extensions;

public class AudioSystem : MonoBehaviour 
{
	private static AudioSystem audioSystem;
	public static AudioSystem Get()
	{
		if (audioSystem == null)
		{
			audioSystem = GameObject.FindGameObjectWithTag("AudioSystem").GetComponent<AudioSystem>();
		}
		return audioSystem;
	}
	
	public AudioSource musicSource;
	public GameObject smokeBuffSound;
	public GameObject uiSound;
	public GameObject playerDeathSound;
	
	public void PlayBuff()
	{
		var go = smokeBuffSound.CreateAsChild(gameObject);
		var src = go.GetComponent<AudioSource>();
		src.pitch = Random.Range(0.5f, 1.5f);
	}
	
	public void PlayUI()
	{
		uiSound.CreateAsChild(gameObject);
	}
	
	public void PlayPlayerDeath()
	{
		playerDeathSound.CreateAsChild(gameObject);
	}
}
