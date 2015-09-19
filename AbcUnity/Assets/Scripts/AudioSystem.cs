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

    public List<AudioClip> LevelMusics = new List<AudioClip>();

    public List<AudioClip> EnemyDeathSoundsL2 = new List<AudioClip>();
    public List<AudioClip> EnemyDeathSoundsL3 = new List<AudioClip>();

    public List<AudioClip> PowerUpSounds = new List<AudioClip>();

    public void PlayMusic(int Index)
    {
        musicSource.clip = LevelMusics[Index];
        musicSource.Play();
    }
	
	public void PlayBuff()
	{
		var go = smokeBuffSound.CreateAsChild(gameObject);
		var src = go.GetComponent<AudioSource>();
		src.pitch = Random.Range(0.5f, 1.5f);
	}

    public void PlayJigSaw(int PowerLevel)
    {
        enemyDeathSound.GetComponent<AudioSource>().clip = EnemyDeathSoundsL2[PowerLevel];
        enemyDeathSound.GetComponent<AudioSource>().pitch = Random.Range(0.75f, 1.25f);
        enemyDeathSound.CreateAsChild(gameObject);
    }
    	
	public void PlayTypewriter()
	{
		enemyDeathSound.GetComponent<AudioSource>().clip = EnemyDeathSoundsL3[Random.Range(0, EnemyDeathSoundsL3.Count)];
        enemyDeathSound.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1.5f);
        enemyDeathSound.CreateAsChild(gameObject);
	}
	
	public void PlayUI()
	{
		uiSound.CreateAsChild(gameObject);
	}

    public void PlayEnemyDeath(int PowerLevel)
    {
        int LevelNumber = PlayArea.LoadedLevel;

        switch (LevelNumber)
        {
            case 1:
                PlayBuff();
                break;

            case 2:
                PlayJigSaw(PowerLevel);
                break;

            case 3:
                PlayTypewriter();
                break;

            default:
                break;
        }
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
