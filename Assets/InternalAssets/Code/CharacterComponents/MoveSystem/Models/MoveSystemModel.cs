using System;
using UnityEngine;

[Serializable]
public class MoveSystemModel : IMoveSystemModel
{
    public event Action<MoveSystemModel> OnModelUpdated;

    private float _moveSpeed;
    private Transform _moveObjectTransform;

    public float MoveSpeed { get => _moveSpeed; set { _moveSpeed = value; OnModelUpdated?.Invoke(this); } }
    Transform IMoveSystemModel.MoveObject { get => _moveObjectTransform; set { _moveObjectTransform = value; OnModelUpdated?.Invoke(this); } }
    
    public MoveSystemModel(float moveSpeed, Transform moveObject)
    {
        _moveObjectTransform = moveObject;
        _moveSpeed = moveSpeed;
    }
}
