using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Mathematics;

[BurstCompile]
public struct MoveObjectJob : IJobParallelForTransform
{
    [ReadOnly] public float DeltaTime;
    [ReadOnly] public float MoveSpeed;

    public void Execute(int index, TransformAccess transform)
    {
        Vector3 forward = transform.rotation * Vector3.forward;
        transform.position += forward * DeltaTime * MoveSpeed;
    }
}
