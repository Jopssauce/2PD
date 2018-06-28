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

	public void Spawn(GameObject prefab, Vector3 pos)
	{
		GameObject temp = Instantiate(prefab, pos, prefab.transform.rotation);
		allPrefabs.Add(temp);
	}

	public Vector2 GetRandomPoint2D(GameObject spawnArea)
	{
		Bounds bounds = spawnArea.GetComponent<Collider2D>().bounds;
		return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
	}

	public IEnumerator Activate()
	{
		yield return new WaitForSeconds(spawnInterval);
	}
	
}
