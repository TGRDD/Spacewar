using UnityEngine;

public class MonoPlayerMoveSystemComponent : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _moveObject;

    private IMoveSystemController _controller;

    private void Start()
    {
        IMoveSystemModel model = new MoveSystemModel(_moveSpeed, _moveObject);
        IMoveSystemController playerController = new PlayerMoveSystemController(model);

        Inizialize(playerController);
    }

    public void Inizialize(IMoveSystemController controller)
    {
        _controller = controller;
    }

    private void Update()
    {
        _controller.Execute();
    }

}
