using System;
using UnityEngine;

[Serializable]
public class PlayerRangeAttackSystemModel : IRangeAttackSystemModel
{
    public Projectile ProjectilePrefab { get => _projectilePrefab; set => throw new NotImplementedException(); }
    public float ProjectileSpeed { get => _projectileSpeed; set => throw new NotImplementedException(); }
    public float Damage { get => _damage; set => throw new NotImplementedException(); }
    public float AttackRate { get => _attackRate; set => throw new NotImplementedException(); }

    public float ProjectileLifeTime { get => _projectileLifeTime; set => throw new NotImplementedException(); }
    public Transform ShootSpawnRoot { get => _shootSpawnRoot; set => throw new NotImplementedException(); }

    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _projectileLifeTime;
    [SerializeField] private Transform _shootSpawnRoot;

    public PlayerRangeAttackSystemModel(Projectile projectilePrefab)
    {
        ProjectilePrefab = projectilePrefab;
        ProjectileSpeed = 5;
        Damage = 5;
        AttackRate = 1;
    }

    public PlayerRangeAttackSystemModel SetProjectileSpeed(float ProjectileSpeed)
    {
        this.ProjectileSpeed = ProjectileSpeed;
        return this;
    }

    public PlayerRangeAttackSystemModel SetProjectileDamage(float ProjectileDamage)
    {
        this.Damage = ProjectileDamage;
        return this;
    }

    public PlayerRangeAttackSystemModel SetAttackRate(float attackRate)
    {
        this._attackRate = attackRate;
        return this;
    }

    public PlayerRangeAttackSystemModel SetShootSpawnRoot(Transform root)
    {
        _shootSpawnRoot = root;
        return this;
    }
}
