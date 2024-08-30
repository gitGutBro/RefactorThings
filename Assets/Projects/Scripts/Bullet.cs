using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce;

    private int _bulletDamage;
    private Rigidbody _rigidbody;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        _bulletForce = 20f;
        _bulletDamage = 20;
    }

    public void OnTriggerEnter(Collider objectPoint)
    {
        if (objectPoint.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_bulletDamage);
            Destroy(gameObject);
        }
    }

    public void MoveToDirection(Vector3 direction) =>
        _rigidbody.AddForce(direction * _bulletForce, ForceMode.Impulse);
}
