using UnityEngine;
using System.Collections;
using Jalomieli.Extensions;

public class EnemySpawn : MonoBehaviour {

    GameObject Enemy;
    GameObject Enemies;
    float SpawnInterval;

    public float ChanceToSpawnSmaller = 40;
    public float ChanceToSpawnPowerUp = 2;

    bool Spawning;
    GameObject Player;
    Character PlayerCharacter;

	void Awake ()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerCharacter = Player.DemandComponent<Character>();
        Enemies = GameObject.Find("Enemies");
        Enemy = (GameObject)Resources.Load("Enemies/EnemyCharacter");
        CharacterVisual.ImageColliders.Clear();
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            CharacterVisual.ImageColliders.Add(transform.GetChild(i).gameObject);
        }
        SpawnInterval = 1.5f;
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        Spawning = true;
        while (Spawning)
        {
            yield return new WaitForSeconds(SpawnInterval);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector2 SpawnPosition = new Vector2(transform.position.x, Random.Range(-2, 4.25f));
        GameObject CurrentEnemy = Enemy.Create(SpawnPosition, Quaternion.identity);
        int RandomLevel = 0;
        float RandomPercentage = Random.Range(0, 100);

        PowerUp powerUp = null;

        if (RandomPercentage < ChanceToSpawnSmaller)
        {
            powerUp = PowerUp.GetRandom();
            RandomLevel = PowerUp.PowerUpLevel;
        }
        else
        {
            if (RandomPercentage > ChanceToSpawnSmaller)
            {
                RandomLevel = Random.Range(PlayerCharacter.PowerLevel, 25);
            }
            else
            {
                RandomLevel = Random.Range(0, PlayerCharacter.PowerLevel);
            }
        }

        var character = CurrentEnemy.DemandComponent<Character>();
        character.PowerLevel = RandomLevel;
        character.PowerUp = powerUp;

        CurrentEnemy.transform.parent = Enemies.transform;
    }
}
