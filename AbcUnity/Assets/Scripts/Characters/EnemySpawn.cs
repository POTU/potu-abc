using UnityEngine;
using System.Collections;
using Jalomieli.Extensions;

public class EnemySpawn : MonoBehaviour {

    GameObject Enemy;
    GameObject Enemies;
    float SpawnInterval;

    public float ChanceToSpawnSmaller = 40;

    bool Spawning;
    GameObject Player;
    Character PlayerCharacter;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerCharacter = Player.DemandComponent<Character>();
        Enemies = GameObject.Find("Enemies");
        Enemy = (GameObject)Resources.Load("Enemies/EnemyCharacter");
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
        
        if(RandomPercentage > ChanceToSpawnSmaller)
        { 
            RandomLevel = Random.Range(PlayerCharacter.PowerLevel, 25);
        }
        else
        {
            RandomLevel = Random.Range(0, PlayerCharacter.PowerLevel);
        }
        
        CurrentEnemy.DemandComponent<Character>().PowerLevel = RandomLevel;
        CurrentEnemy.transform.parent = Enemies.transform;
    }
}
