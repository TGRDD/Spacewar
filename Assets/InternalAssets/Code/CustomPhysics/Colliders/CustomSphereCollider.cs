using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CustomSphereCollider : MonoBehaviour, ICustomCollider
{
    public event Action<ICustomCollider> OnCollideOther;
    [field: SerializeField] public float radius { get; private set; }
    [field: SerializeField] public CollisionMask colliderMask { get; private set; }

    [field: SerializeField] public CollisionMask[] collisionMasks { get; private set; }
    public float Radius => radius;
    public GameObject ColliderGameObject => this.gameObject;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnEnable()
    {
        CustomMonoPhysicsContainer.PhysicsColliders.Add(this);
    }

    private void OnDisable()
    {
        CustomMonoPhysicsContainer.PhysicsColliders.Remove(this);
    }

    public IEnumerator CheckCollision(ICustomCollider other)
    {
        Debug.Log("CheckCollisionProcces");
        float distance = Vector3.Distance(transform.position, other.ColliderGameObject.transform.position);
        bool result = distance < (radius + other.Radius);
        if (result) OnCollideOther?.Invoke(other);
        Debug.Log("SUCCES COLLISION");
        yield return null;
    }

    public bool CollideEachOther(ICustomCollider other)
    {
        return collisionMasks.Contains(other.colliderMask);
    }
}
