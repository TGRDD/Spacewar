using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] _spawnPointsArray;
    [SerializeField] private AIMonoMoveSystem _objectPrefab;
    [SerializeField] private Quaternion _objectRotation;

    private ObjectPool<AIMonoMoveSystem> _objectPool;

    private Vector3 _randomSpawnPoint => _spawnPointsArray[Random.Range(0, _spawnPointsArray.Length)];

    private void OnDrawGizmos()
    {
        if (_spawnPointsArray == null) return;
        foreach (var spawnPoint in _spawnPointsArray)
        {
            Gizmos.DrawSphere(spawnPoint, 0.1f);
        }    
    }

    private void Start()
    {
        _objectPool = new ObjectPool<AIMonoMoveSystem>(
            createFunc: CreateObject,
            actionOnGet: GetObject,
            actionOnRelease: ReleaseObject,
            actionOnDestroy: DestroyObject);

        StartCoroutine(SpawnProcces());
    }

    public AIMonoMoveSystem CreateObject()
    {
        AIMonoMoveSystem obj = GameObject.Instantiate(_objectPrefab, _randomSpawnPoint, _objectRotation);
        obj.OnRelease += _objectPool.Release;
        obj.Load();
        obj.Init(_randomSpawnPoint);
        return obj;
    }

    public void GetObject(AIMonoMoveSystem obj)
    {
        obj.Init(_randomSpawnPoint);
        obj.transform.position = _randomSpawnPoint;
        obj.gameObject.SetActive(true);

    }

    public void ReleaseObject(AIMonoMoveSystem obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void DestroyObject(AIMonoMoveSystem obj)
    {
        GameObject.Destroy(obj.gameObject);
    }

    public IEnumerator SpawnProcces()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            for (int i = 0; i < 10; i++)
            {
                _objectPool.Get();
            }
        }
    }
}
