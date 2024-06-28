using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action<Projectile> OnRelease;

    private float _lifeTime;
    private float _moveSpeed;
    private float _damage;

    public void Init(float LifeTime, float MoveSpeed, float Damage, Vector3 SpawnPosition, Quaternion rotation)
    {
        transform.position = SpawnPosition;
        transform.rotation = rotation;
        _lifeTime = LifeTime;
        _moveSpeed = MoveSpeed;
        _damage = Damage;
    }



    public void Release()
    {
        OnRelease?.Invoke(this);
    }

    //TODO: CHANGE TO UNI JOB
    private void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;

        _lifeTime -= Time.deltaTime;

        if (_lifeTime < 0)
        {
            Release();
        }
    }

}
