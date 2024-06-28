using UnityEngine;

public class PlayerMoveSystemController : IMoveSystemController
{
    private IMoveSystemModel _model;

    private Transform moveObject => _model.MoveObject.transform;
    private float moveSpeed => _model.MoveSpeed * Time.deltaTime;

    private Vector3 MovedPosition;
    public PlayerMoveSystemController(IMoveSystemModel model)
    {
        _model = model;
    }

    public void Execute()
    {
        //TODO: ADD IINPUTSYSTEM

        MovedPosition = Vector3.MoveTowards(moveObject.position, fixedInputPosition() , moveSpeed);
        MovedPosition.y = moveObject.position.y;

        moveObject.position = MovedPosition;
    }

    //TODO: MOVE TO INPUT SYSTEM
    private Vector3 fixedInputPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10);

        return ray.GetPoint(Vector3.Distance(Camera.main.transform.position, moveObject.position));
    }
}
