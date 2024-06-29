using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public event Action<PoolObject> OnRelease;

    public void Release()
    {
        OnRelease?.Invoke(this);
    }
}
