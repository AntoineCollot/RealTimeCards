using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour {

    public Projectile projectilePrefab;

    public Transform SpawnPosition;

    public float delay;

    Transform target;

	public void Attack(Health target)
    {
        this.target = target.transform;
        Invoke("Spawn", delay);
    }

    void Spawn()
    {
        Instantiate(projectilePrefab, SpawnPosition.position, Quaternion.identity).target = target;
    }
}
