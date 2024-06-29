using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSphereCollider : MonoBehaviour, ICustomCollider
{
    public event Action<ICustomCollider> OnCollideOther;

    [field: SerializeField] public float radius { get; private set; }
    [field: SerializeField] public CollisionMask colliderMask { get; private set; }
    [field: SerializeField] public CollisionMask[] collisionMasks { get; private set; }

    private HashSet<CollisionMask> collisionMaskSet;

    public float Radius => radius;
    public GameObject ColliderGameObject => this.gameObject;

    private IEnumerator collisionDetectionRoutine;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Awake()
    {
        collisionMaskSet = new HashSet<CollisionMask>(collisionMasks);
        collisionDetectionRoutine = CollisionDetectionProcces();
    }


    private void OnEnable()
    {
        StartCoroutine(collisionDetectionRoutine);
    }

    private void OnDisable()
    {
        StopCoroutine(collisionDetectionRoutine);
    }

    private void Start()
    {
        CustomMonoPhysicsContainer.PhysicsColliders.Add(this);
    }

    private void OnDestroy()
    {
        CustomMonoPhysicsContainer.PhysicsColliders.Remove(this);
    }

    private IEnumerator CollisionDetectionProcces()
    {
        while (true)
        {
            yield return new WaitForSeconds(CustomMonoPhysicsContainer.CallPeriod);

            if (!isActiveAndEnabled)
                continue;

            for (int i = 0; i < CustomMonoPhysicsContainer.PhysicsColliders.Count; i++)
            {
                ICustomCollider otherCollider = CustomMonoPhysicsContainer.PhysicsColliders[i];

                if (otherCollider == (ICustomCollider)this ||!CollideEachOther(otherCollider) || !otherCollider.ColliderGameObject.activeInHierarchy)
                    continue;

                CheckCollision(otherCollider);
            }
        }
    }

    public void CheckCollision(ICustomCollider other)
    {
        float distance = Vector3.Distance(transform.position, other.ColliderGameObject.transform.position);
        if (distance < (radius + other.Radius))
        {
            Debug.Log("Saw collision");
            OnCollideOther?.Invoke(other);
        }
    }

    public bool CollideEachOther(ICustomCollider other)
    {
        return collisionMaskSet.Contains(other.colliderMask);
    }
}

public enum CollisionMask
{
    Player,
    PlayerProjectile,
    Enemy,
    EnemyProjectile
}
