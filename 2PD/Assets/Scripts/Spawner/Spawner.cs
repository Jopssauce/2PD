using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[System.Serializable]
public class SpawnerEvents : UnityEvent<GameObject> {}

public class Spawner : MonoBehaviour 
{
	public bool isActivated;
	public bool infiniteSpawning;
	public float maxSpawn;
	public float spawnInterval;
	public float spawnWaves;
	public float currentWave;
	public float enemiesPerWave;
	public Sprite on;
	public Sprite off;
	public List<SpawnEntities> prefabs;
	public List<GameObject> allPrefabs;
	public List<GameObject> spawnAreas;
	public SpawnerEvents EventOnActivate;
	public SpawnerEvents EventOnDeActivate;

	void Start()
	{
		EventOnActivate = new SpawnerEvents();
		EventOnDeActivate = new SpawnerEvents();
	}

	public void Spawn(GameObject prefab, Vector2 pos)
	{
		GameObject temp = Instantiate(prefab, pos, prefab.transform.rotation);
		allPrefabs.Add(temp);
	}

	public Vector2 GetRandomPoint2D(GameObject spawnArea)
	{
		Bounds bounds = spawnArea.GetComponent<Collider2D>().bounds;
		return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
	}

	public void SpawnWave()
	{
		int spawnIndex = Random.Range(0, allPrefabs.Count - 1);
		int prefabIndex = Random.Range(0, prefabs.Count - 1);
		
		for (int i = 0; i < enemiesPerWave; i++)
		{
			GameObject toSpawn = prefabs[prefabIndex].prefab.gameObject;
			SpawnEntities toSpawnEntity = prefabs[prefabIndex];
			GameObject spawnArea = spawnAreas[spawnIndex];

			if (allPrefabs.Count - 1 < maxSpawn && infiniteSpawning)
			{
				if (toSpawnEntity.amountToSpawn < 
				allPrefabs.Count(p => p.gameObject.GetComponent<PlayerController>().ID == toSpawnEntity.prefab.GetComponent<PlayerController>().ID))
				{
					Spawn(toSpawn, GetRandomPoint2D(spawnArea));
				}
			}
			else if(allPrefabs.Count - 1 < maxSpawn && !infiniteSpawning && currentWave != spawnWaves)
			{
				if (toSpawnEntity.amountToSpawn < 
				allPrefabs.Count(p => p.gameObject.GetComponent<PlayerController>().ID == toSpawnEntity.prefab.GetComponent<PlayerController>().ID))
				{
					Spawn(toSpawn, GetRandomPoint2D(spawnArea));
				}
				
			}
		}
	}

	public IEnumerator Spawning()
	{
		yield return new WaitForSeconds(spawnInterval);
		currentWave++;

	}

	public void Activate()
	{
		StartCoroutine(Spawning());
	}

	public void DeActivate()
	{
		StopCoroutine(Spawning());
	}
	
}
