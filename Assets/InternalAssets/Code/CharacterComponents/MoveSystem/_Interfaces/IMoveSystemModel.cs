using UnityEngine;

public interface IMoveSystemModel
{
    public Transform MoveObject { get; set; }
    public float MoveSpeed { get; set; }
}
