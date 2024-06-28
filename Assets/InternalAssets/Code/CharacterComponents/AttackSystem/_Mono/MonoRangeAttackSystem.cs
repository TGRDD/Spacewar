using UnityEngine;

public class MonoRangeAttackSystem : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerRangeAttackSystemModel model;

    private IAttackSystemController controller;
    private void Start()
    {
        controller = new PlayerRangeAttackSystemController(model);
    }

    private void Update()
    {
        controller.Execute();
    }
}
