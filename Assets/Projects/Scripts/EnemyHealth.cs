public sealed class EnemyHealth : Health
{
    protected sealed override void Die()
    {
        GameManager.EnemyKilled();
        Destroy(gameObject); 
    }
}