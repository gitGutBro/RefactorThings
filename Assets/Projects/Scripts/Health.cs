using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private HealthBar _healthBar;

    private int _currentHealth;
    private GameManager _gameManager;

    protected GameManager GameManager => _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    protected abstract void Die();
}