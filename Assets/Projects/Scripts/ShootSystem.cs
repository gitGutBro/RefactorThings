using UnityEngine;

public abstract class ShootSystem : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bulletPrefab;

    protected void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, Camera.main.transform.rotation);

        bullet.MoveToDirection(_firePoint.forward);
    }
}