using System;
using System.Collections;
using UnityEngine;

public interface ICustomCollider
{
    public event Action<ICustomCollider> OnCollideOther;

    public CollisionMask colliderMask { get; }

    public CollisionMask[] collisionMasks { get; }
    
    public float Radius { get; }
    public GameObject ColliderGameObject { get; }
    public void CheckCollision(ICustomCollider otherObject);

    public bool CollideEachOther(ICustomCollider other);
}
