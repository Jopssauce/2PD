using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[System.Serializable]
public class SpawnerEvents : UnityEvent {}

public class Spawner : MonoBehaviour 
{
	public bool isActivated;
	public bool infiniteSpawning;
	public bool roundRobin;
	public bool activateOnTriggerEnter;
	public bool autoDeactivate;
	public float maxTotalSpawn;
	public float waveInterval;
	public float spawnInterval;
	public float spawnWaves;
	public float currentWave;
	public float enemiesPerWave;
	int spawnIndex;
	public Sprite on;
	public Sprite off;
	public List<SpawnEntities> prefabs;
	public List<GameObject> allSpawnedPrefabs;
	public List<GameObject> spawnAreas;
	public SpawnerEvents EventActivate;
	public SpawnerEvents EventDeactivate;
	public SpawnerEvents EventCleanList;

	public SpawnerEvents EventOnActivate;
	public SpawnerEvents EventOnDeactivate;
	public SpawnerEvents EventOnCleanList;

	IEnumerator spawnPrefab;

	void Start()
	{
		//EventOnActivate = new SpawnerEvents();
		//EventOnDeActivate = new SpawnerEvents();

		EventActivate.AddListener(Activate);
		EventDeactivate.AddListener(Deactivate);
		EventCleanList.AddListener(CleanSpawnedPrefabsList);
	}

	public void Spawn(GameObject prefab, Vector2 pos)
	{
		GameObject temp = Instantiate(prefab, pos, prefab.transform.rotation);
		AttachCleanListToObject(temp);
		allSpawnedPrefabs.Add(temp);
	}

	public Vector2 GetRandomPoint2D(GameObject spawnArea)
	{
		Bounds bounds = spawnArea.GetComponent<Collider2D>().bounds;
		return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
	}

	public void SpawnWave()
	{
		int tempSpawnIndex = spawnIndex;
		if(roundRobin)
		{
			if(spawnIndex > spawnAreas.Count - 1) spawnIndex = 0;
			tempSpawnIndex = spawnIndex;
			spawnIndex++;
		}
		else
		{
			tempSpawnIndex = Random.Range(0, spawnAreas.Count);
		}
		int prefabIndex = Random.Range(0, prefabs.Count);
		Debug.Log(tempSpawnIndex);
		
		spawnPrefab = SpawnPrefab(prefabIndex, tempSpawnIndex);
		StartCoroutine(SpawnPrefab(prefabIndex, tempSpawnIndex));
		
	}

	public IEnumerator Spawning()
	{
		
		while (spawnWaves > 0 || infiniteSpawning)
		{
			
			if (currentWave != spawnWaves && !infiniteSpawning)
			{
				SpawnWave();
				currentWave++;
			}
			if (infiniteSpawning)
			{
				SpawnWave();
				currentWave++;
			}
			yield return new WaitForSeconds(waveInterval);
			if(autoDeactivate) EventDeactivate.Invoke();
			StopCoroutine(spawnPrefab);
		}

	}

	public IEnumerator SpawnPrefab(int prefabIndex, int tempSpawnIndex)
	{
		float counter = 0;
		while (counter != enemiesPerWave)
		{
			GameObject toSpawn = prefabs[prefabIndex].prefab.gameObject;
			SpawnEntities toSpawnEntity = prefabs[prefabIndex];
			GameObject spawnArea = spawnAreas[tempSpawnIndex];
			int spawnEntityCount = allSpawnedPrefabs.Count(p => p.gameObject.GetComponent<PlayerController>().ID == toSpawnEntity.prefab.GetComponent<PlayerController>().ID);

			if (allSpawnedPrefabs.Count - 1 <= maxTotalSpawn && infiniteSpawning)
			{
				if (spawnEntityCount <= toSpawnEntity.amountToSpawn)
				{
					Spawn(toSpawn, GetRandomPoint2D(spawnArea));
				}
			}
			else if(allSpawnedPrefabs.Count - 1 <= maxTotalSpawn && !infiniteSpawning)
			{
				if (spawnEntityCount <= toSpawnEntity.amountToSpawn)
				{
					Spawn(toSpawn, GetRandomPoint2D(spawnArea));
				}
				
			}
			counter++;
			yield return new WaitForSeconds(spawnInterval);
		}
		
		
	}

	public void Activate()
	{
		if (!isActivated)
		{
			isActivated = true;
			Debug.Log("Spawner Activated");
			StartCoroutine(Spawning());
			OnSprite();
			EventOnActivate.Invoke();
		}
	}

	public void Deactivate()
	{
		if (isActivated)
		{
			isActivated = false;
			StopAllCoroutines();
			OffSprite();
			EventOnDeactivate.Invoke();
		}
	}

	public void OnSprite()
	{
		if (GetComponent<SpriteRenderer>() && on != null)
		{
			GetComponent<SpriteRenderer>().sprite = on;
		}
	}

	public void OffSprite()
	{
		if (GetComponent<SpriteRenderer>() && off != null)
		{
			GetComponent<SpriteRenderer>().sprite = off;
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(!activateOnTriggerEnter) return;
		EventActivate.Invoke();

	}

	public void CleanSpawnedPrefabsList()
	{
		allSpawnedPrefabs = allSpawnedPrefabs.Where(obj => obj != null).ToList();
		EventOnCleanList.Invoke();
	}

	public void AttachCleanListToObject(GameObject obj)
	{
		if(obj.GetComponent<Health>())
		{
			obj.GetComponent<Health>().EventOnDestroy.AddListener(CleanSpawnedPrefabsList);
		}
	}
	
}
