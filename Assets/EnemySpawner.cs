﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    float spawnDistance = 15f;

    float enemyRate = 5;
    float nextEnemy = 1;

	// Update is called once per frame
	void Update () {
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0) {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;
            if (enemyRate < 1)
                enemyRate = 1;


            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;


            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);


        }
	}
}
