using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(0)] private int _minObjectsCount;

    [SerializeField] private Initializable<AudioSource> _prefab;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private AudioSource _collectedSoundSource;

    private List<Vector3> _spawnPointsPosition;

    private void Awake()
    {
        _spawnPointsPosition = _spawnPoints.GetComponentsInChildren<SpawnPoint>()
            .Select(spawnPoint => spawnPoint.transform.position)
            .ToList();
    }

    private void Start()
    {
        if (_minObjectsCount > _spawnPointsPosition.Count)
            throw new System.InvalidOperationException();

        int objectsCount = Random.Range(_minObjectsCount, _spawnPointsPosition.Count);

        for (int i = 0; i < objectsCount; i++)
        {
            int spawnPointIndex = Random.Range(0, _spawnPointsPosition.Count - 1);

            Initializable<AudioSource> example = Instantiate(_prefab, _spawnPointsPosition[spawnPointIndex], Quaternion.identity);

            example.Init(_collectedSoundSource);
            _spawnPointsPosition.RemoveAt(spawnPointIndex);
        }
    }
}
