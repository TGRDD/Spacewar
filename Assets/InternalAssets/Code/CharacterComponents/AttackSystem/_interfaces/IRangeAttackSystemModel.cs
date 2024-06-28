using UnityEngine;

public interface IRangeAttackSystemModel : IAttackSystemModel
{
    public Projectile ProjectilePrefab { get; set; }
    public Transform ShootSpawnRoot { get; set; }
    public float ProjectileSpeed { get; set; }
    public float ProjectileLifeTime { get; set; }
}
