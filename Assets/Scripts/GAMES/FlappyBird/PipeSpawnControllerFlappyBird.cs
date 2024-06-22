using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class PipeSpawnControllerFlappyBird : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private List<GameObject> _pipes = new();

        [SerializeField] private float _maxSpawnPos, _minSpawnPos;

        [SerializeField] private float _spawnRate = 1;
        [SerializeField] private int _spawnCount = 15;

        private int _objectIndex = 0;

        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                GameObject newObject = Instantiate(_prefab, transform.position, Quaternion.identity);
                newObject.transform.parent = transform;
                newObject.SetActive(false);
                _pipes.Add(newObject);
            }
        }

        private void Start ()
        {
            Spawn();

            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }
      
        private void StartSpawn()
        {
            if (_spawnCoroutine == null)
            {
                _spawnCoroutine = StartCoroutine(SpawnCoroutine());
            }
        }

        private void StopSpawn()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }       

        private void Spawn()
        {
            if (_objectIndex >= _pipes.Count)
            {
                _objectIndex = 0;
            }
            _pipes[_objectIndex].transform.position = transform.position;
            _pipes[_objectIndex].transform.position += Vector3.up * UnityEngine.Random.Range(_minSpawnPos, _maxSpawnPos);
            _pipes[_objectIndex].SetActive(true);
            _objectIndex++;
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                Spawn();
            }
        }
    }
}

