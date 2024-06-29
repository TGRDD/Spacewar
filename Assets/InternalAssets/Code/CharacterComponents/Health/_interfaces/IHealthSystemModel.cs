public interface IHealthSystemModel
{
    public int MaxHealth { get; }
    public int Health { get; }

    public void SetHealth(int health);
}
