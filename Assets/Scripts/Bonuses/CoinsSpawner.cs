using System.Linq;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private AudioSource _collectingSoundSource;

    private Vector3[] _spawnPointsPosition;

    private void Awake()
    {
        _spawnPointsPosition = _spawnPoints.GetComponentsInChildren<SpawnPoint>()
            .Select(spawnPoint => spawnPoint.transform.position)
            .ToArray();
    }

    private void Start()
    {
        int minCoinsCount = 5;

        int coinsCount = Random.Range(minCoinsCount, _spawnPointsPosition.Length);

        for (int i = 0; i < coinsCount; i++)
        {
            int spawnPointIndex = Random.Range(0, _spawnPointsPosition.Length);

            Coin coin = Instantiate(_coin, _spawnPointsPosition[spawnPointIndex], Quaternion.identity);

            coin.Init(_collectingSoundSource);
        }
    }
}
