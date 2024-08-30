public sealed class PlayerHealth : Health
{
    private bool _isShielded;

    public override void TakeDamage(int damage)
    {
        if (_isShielded)
            return;
        
        base.TakeDamage(damage);
    }

    public void SetShieldState(bool state) =>
        _isShielded = state;

    protected sealed override void Die() =>
        GameManager.PlayerDied();
}