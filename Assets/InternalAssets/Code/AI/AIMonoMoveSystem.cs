using System;
using UnityEngine;


public class AIMonoMoveSystem : PoolObject
{
    [Header("Config")]
    [SerializeField] private float _speed = 250;
    [SerializeField] private float _lifeTime = 20;
    private float _currentLifeTime;

    public new event Action<AIMonoMoveSystem> OnRelease;


    
    private AIMoveSystemController controller;
    private MoveSystemModel model;

    public override void Release()
    {
        if (gameObject.activeInHierarchy)
        OnRelease?.Invoke(this);
        
    }

    public void Load()
    {
        model = new MoveSystemModel(_speed, transform);
        controller = new AIMoveSystemController(model);
    }

    public void Init(Vector3 spawnPos)
    {
        transform.position = spawnPos;
        _currentLifeTime = _lifeTime;
    }

    private void Update()
    {
        if (controller == null) return;
        controller.Execute();

        _currentLifeTime -= Time.deltaTime;

        if (_currentLifeTime < 0) Release();
    }
}
