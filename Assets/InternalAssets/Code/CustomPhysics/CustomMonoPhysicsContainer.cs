using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMonoPhysicsContainer : MonoBehaviour
{
    [SerializeField] private float CallPeriod;

    public static List<ICustomCollider> PhysicsColliders = new List<ICustomCollider>();

    

    public static IEnumerator CheckAllCollisions()
    {
        if (PhysicsColliders == null) yield break;

        for (int i = 0; i < PhysicsColliders.Count; i++)
        {
            for (int j = 0; j < PhysicsColliders.Count; j++)
            {
                if (!PhysicsColliders[i].ColliderGameObject.activeSelf || !PhysicsColliders[j].ColliderGameObject.activeSelf) continue;
                if (PhysicsColliders[i] == PhysicsColliders[j]) continue;
                if (PhysicsColliders[i].CollideEachOther(PhysicsColliders[j])) continue;


                yield return PhysicsColliders[i].CheckCollision(PhysicsColliders[j]);
            }
        }
     
    }

    private void Start()
    {
        StartCoroutine(CheckCollisionProcces());
    }

    private IEnumerator CheckCollisionProcces()
    {
        Debug.Log("StartCollisionRoutine");
        while (true)
        {
            yield return new WaitForSecondsRealtime(CallPeriod);
            yield return CheckAllCollisions();
        }
    }
}

public enum CollisionMask
{
    Player,
    PlayerProjectile,
    Enemy,
    EnemyProjectile
}
