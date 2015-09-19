using UnityEngine;
using System.Collections.Generic;
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
    public GameObject enemyDeathSound;
    public GameObject powerUpSound;

    public List<AudioClip> EnemyDeathSounds = new List<AudioClip>();
    public List<AudioClip> PowerUpSounds = new List<AudioClip>();
    
	
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

    public void PlayEnemyDeath(int PowerLevel)
    {
        print(PowerLevel);
        enemyDeathSound.GetComponent<AudioSource>().clip = EnemyDeathSounds[PowerLevel];
        enemyDeathSound.CreateAsChild(gameObject);
    }

    public void PlayPowerUp(int id)
    {
        powerUpSound.GetComponent<AudioSource>().clip = PowerUpSounds[id];
        powerUpSound.CreateAsChild(gameObject);
    }
	
	public void PlayPlayerDeath()
	{
		playerDeathSound.CreateAsChild(gameObject);
	}
}
