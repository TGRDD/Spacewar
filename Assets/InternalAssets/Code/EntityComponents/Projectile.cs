using System;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class Projectile : PoolObject
{

    private float _lifeTime;
    private float _moveSpeed;
    private float _damage;

    private JobHandle moveJobHandle;
    private TransformAccessArray _transformAccessArray;

    public void Init(float LifeTime, float MoveSpeed, float Damage, Vector3 SpawnPosition, Quaternion rotation)
    {
        transform.position = SpawnPosition;
        transform.rotation = rotation;
        _lifeTime = LifeTime;
        _moveSpeed = MoveSpeed;
        _damage = Damage;

        if (_transformAccessArray.isCreated)
        {
            _transformAccessArray.Dispose();
        }

        _transformAccessArray = new TransformAccessArray(1);
        _transformAccessArray.Add(transform);
    }


    //TODO: CHANGE TO UNI JOB
    private void Update()
    {
        moveJobHandle.Complete();


        MoveObjectJob job = new MoveObjectJob
        {
            DeltaTime = Time.deltaTime,
            MoveSpeed = _moveSpeed,
        };

        moveJobHandle = job.Schedule(_transformAccessArray);
        JobHandle.ScheduleBatchedJobs();


        _lifeTime -= Time.deltaTime;

        if (_lifeTime < 0)
        {
            Release();
        }
    }

    private void OnDestroy()
    {
        if (_transformAccessArray.isCreated)
        {
            _transformAccessArray.Dispose();
        }
    }

}
