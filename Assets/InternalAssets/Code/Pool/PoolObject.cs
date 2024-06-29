using System;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public virtual event Action<PoolObject> OnRelease;

    public virtual void Release()
    {
        OnRelease?.Invoke(this);
    }

}
