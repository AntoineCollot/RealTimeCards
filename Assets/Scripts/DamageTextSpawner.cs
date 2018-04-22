using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextSpawner : MonoBehaviour {

    public DamageText damageTextPrefab;

    public float spawnRadius;

    public static DamageTextSpawner Instance;

    void Awake()
    {
        Instance = this;
    }
	
	public void SpawnDamage(int value,Vector2 position)
    {
        Vector2 randPosition = position + new Vector2(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius) * 0.5f);
        Instantiate(damageTextPrefab, randPosition, Quaternion.identity, transform).Init(value);
    }
}
