using UnityEngine;
using UnityEngine.Pool;

public class PlayerRangeAttackSystemController : IAttackSystemController
{
    private IRangeAttackSystemModel _model;
    private ObjectPool<PoolObject> _projectilePool;

    private float attackRate => _model.AttackRate;
    private float currentAttackRateCount;

    public PlayerRangeAttackSystemController(IRangeAttackSystemModel model)
    {
        _model = model;

        _projectilePool = new ObjectPool<PoolObject>(
            createFunc: CreateProjectile,
            actionOnGet: GetProjectile,
            actionOnRelease: ReleaseProjectile,
            actionOnDestroy: DestroyProjectile);
    }

    public Projectile CreateProjectile()
    {
        Projectile obj = GameObject.Instantiate(_model.ProjectilePrefab, _model.ShootSpawnRoot.position, Quaternion.identity);
        obj.OnRelease += _projectilePool.Release;
        InizializeProjectileByModel(obj);
        return obj;
    }

    public void GetProjectile(PoolObject obj)
    {
        obj.gameObject.SetActive(true);
        InizializeProjectileByModel(obj);

    }
    
    public void ReleaseProjectile(PoolObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void DestroyProjectile(PoolObject obj)
    {
        GameObject.Destroy(obj.gameObject);
    }

    public void Execute()
    {
        if (currentAttackRateCount <= 0)
        {
            _projectilePool.Get();
            currentAttackRateCount = attackRate;
        }
        else
        {
            currentAttackRateCount -= Time.deltaTime;
        }
    }

    private void InizializeProjectileByModel(PoolObject obj)
    {
        Projectile proj = obj.GetComponent<Projectile>();
        proj.Init(_model.ProjectileLifeTime, _model.ProjectileSpeed, _model.Damage, _model.ShootSpawnRoot.position, _model.ShootSpawnRoot.rotation);
    }
}
