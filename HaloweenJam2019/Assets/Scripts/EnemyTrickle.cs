﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrickle : MonoBehaviour
{
    public Transform[] nodes;
    public GameObject player;
    public GameObject zombie;

    [Header("Size Constraints")]
    public Vector2 initializeRateDis;
    public Vector2 spawnDis;

    [Header("Bools")]
    public bool[] isSpawning;
    public bool[] hasSpawned;

    [Header("Serialized Stuff")]
    [SerializeField] private float[] playerDistance;
    [SerializeField] private float spawnRate;

    private void DistanceUpdate()
    {
        for (int i = 0; i < nodes.Length; i += 1)
        {
            playerDistance[i] = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - nodes[i].position.x, 2) + Mathf.Pow(player.transform.position.y - nodes[i].position.y, 2) + Mathf.Pow(player.transform.position.z - nodes[i].position.z, 2));
            if (playerDistance[i] > initializeRateDis.x && playerDistance[i] < initializeRateDis.y)
            {
                isSpawning[i] = true;
            }
            else
            {
                isSpawning[i] = false;
            }
        }
        Invoke("DistanceUpdate", 1f);
    }

    void Start()
    {
        for(int i = 0; i < nodes.Length; i += 1)
        {
            playerDistance[i] = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - nodes[i].position.x, 2) + Mathf.Pow(player.transform.position.y - nodes[i].position.y, 2) + Mathf.Pow(player.transform.position.z - nodes[i].position.z, 2));
            isSpawning[i] = false;
            hasSpawned[i] = false;
        }

        Invoke("DistanceUpdate", 1f);
    }
    void Update()
    {
        for(int i = 0; i < nodes.Length; i += 1)
        {
            if(isSpawning[i])
            {
                StartCoroutine("Spawning", i);
            }
        }
    }
    IEnumerator Spawning(int i)
    {
        if(!hasSpawned[i])
        {
            hasSpawned[i] = true;
            yield return new WaitForSeconds(Random.Range(0, spawnRate));

            Instantiate(zombie, nodes[i].position + new Vector3(Random.Range(-spawnDis.x, spawnDis.x), 0f, Random.Range(-spawnDis.y, spawnDis.y)), transform.rotation);

            yield return new WaitForSeconds(spawnRate * (nodes.Length - 2));
            hasSpawned[i] = false;
        }
    }
}