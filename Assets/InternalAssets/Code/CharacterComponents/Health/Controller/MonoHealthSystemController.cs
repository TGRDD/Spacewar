using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CustomSphereCollider))]
public class MonoHealthSystemController : MonoBehaviour, IHealthSystemController
{
    public UnityEvent OnDead;

    private IHealthSystemModel healthSystemModel = new HealthSystemModel(1);

    [SerializeField] private CustomSphereCollider _collider;

    private int health => healthSystemModel.Health;
    private bool _isDead = false;

    private void OnValidate()
    {
        _collider = GetComponent<CustomSphereCollider>();
    }

    private void OnEnable()
    {
        _collider.OnCollideOther += OnCollide;
        _isDead = false;
    }

    private void OnDisable()
    {
        _collider.OnCollideOther -= OnCollide;
    }

    public void OnCollide(ICustomCollider other)
    {
        Instakill();
    }


    public void Instakill()
    {
        if (_isDead) return;

        _isDead = true;

        OnDead?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) damage = 0;
        healthSystemModel.SetHealth(health - damage);

        if (health <= 0)
        {
            OnDead?.Invoke();
        }

    }
}
