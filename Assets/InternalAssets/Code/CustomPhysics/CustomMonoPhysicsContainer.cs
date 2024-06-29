using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMonoPhysicsContainer
{
    public static List<ICustomCollider> PhysicsColliders = new List<ICustomCollider>();
    public static float CallPeriod => Time.deltaTime/2;
}

