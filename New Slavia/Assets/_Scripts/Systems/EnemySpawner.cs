using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _unitPerSecond;
    private float currentCooldown;
    [SerializeField] private List<EnemyStats> _enemies;
    [SerializeField] private List<Transform> _spawnZones;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentCooldown <= 0)
        {
            int numberOfSpawner = Random.Range(0, _spawnZones.Count);
            int numberOfUnit = 0;
            Instantiate(_enemies[numberOfUnit], GetRandomPositionInSpawnZone(numberOfSpawner), Quaternion.identity);
            currentCooldown = 1 / _unitPerSecond;
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private Vector3 GetRandomPositionInSpawnZone(int numberOfSpawner)
    {
        Transform spawner = _spawnZones[numberOfSpawner];
        float x = spawner.position.x + Random.Range(-spawner.localScale.x, spawner.localScale.x);
        float y = spawner.position.y + Random.Range(-spawner.localScale.y, spawner.localScale.y);
        float z = spawner.position.z;
        return new Vector3(x, y, z);
    }
}