using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnCarrotTomate : MonoBehaviour
{
    [Header("PrefabOption")]
    [SerializeField] private GameObject[] _objectForSpawnOnGarden;
    [SerializeField] private Transform[] _spawnPointForVegetables;

    [SerializeField] private List<GameObject> _vegetablesWasSpawned;
    
    [Header("ValueForSpawn")]
    [SerializeField] private int _minCountForSpawnVegetables;
    [SerializeField] private int _maxCountForSpawnVegetables;

    [Header("SpawnPlace")]
    [SerializeField] private int[] _randomPlaceForSpawnVegetables;

    private int _randomCountSpawnVegetables;
    

    private int _counter;

    private void Start()
    {
        _randomCountSpawnVegetables = Random.Range(_minCountForSpawnVegetables, _maxCountForSpawnVegetables - 1);

        for(int i = 0; i <= (_randomCountSpawnVegetables); i++)
        {
            _vegetablesWasSpawned.Add(Instantiate(_objectForSpawnOnGarden[(_counter < (_randomCountSpawnVegetables/2) ? 0 : 1)]));

            _counter++;
        }

        _randomPlaceForSpawnVegetables = new int[_vegetablesWasSpawned.Count];

        for(int i = 0; i <= (_randomCountSpawnVegetables); i++)
        {
            _randomPlaceForSpawnVegetables[i] = Random.Range(0, _spawnPointForVegetables.Length - 1);

            for(int j = (_randomPlaceForSpawnVegetables.Length - 1); j >= 0; j--)
            {
                int temp = _randomPlaceForSpawnVegetables[i];

                if(temp == _randomPlaceForSpawnVegetables[j])
                {
                    _randomPlaceForSpawnVegetables[i]++;
                }
            }
        }

        for(int i = 0; i <= (_vegetablesWasSpawned.Count - 1); i++)
        {
            _vegetablesWasSpawned[i].transform.position = _spawnPointForVegetables[_randomPlaceForSpawnVegetables[i]].transform.position;
        }
    }
}
