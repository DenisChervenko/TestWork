using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PshenicaRandomSpawn : MonoBehaviour
{
    [Header("PrefabOption")]
    [SerializeField] private GameObject _prefabForSpawn;
    [SerializeField] private List<GameObject> _prefabWasSpawned;
    [SerializeField] private int _countPrefabForSpawn;

    [Header("SpawnOption")]
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private int[] _randomSpawnPointNumber;

    private void Start()
    {
        for(int i = 0; i <= (_countPrefabForSpawn); i++)
        {
            _prefabWasSpawned.Add(Instantiate(_prefabForSpawn));
        }

        _randomSpawnPointNumber = new int[_prefabWasSpawned.Count];

        // assign random value for spawn place
        for(int  i = 0; i <= (_countPrefabForSpawn); i++)
        {
            _randomSpawnPointNumber[i] = Random.Range(0, _spawnPoint.Length);

            //dodge duplicate
            for(int j = (_countPrefabForSpawn); j >= 0; j--)
            {
                int temp = _randomSpawnPointNumber[i];

                if(temp == _randomSpawnPointNumber[j])
                {
                    _randomSpawnPointNumber[i]++;
                }
            }
        }

        
        //move pshenica to spawn point
        for(int i = 0; i <= (_countPrefabForSpawn); i++)
        {
            _prefabWasSpawned[i].transform.position = _spawnPoint[_randomSpawnPointNumber[i]].transform.position;
        }
    }
}
