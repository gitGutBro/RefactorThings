using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : ShootSystem
{
    [SerializeField] private float _shootingRange = 15f;
    [SerializeField] private float _stopDistance = 10f; 
    [SerializeField] private float _shootingInterval = 2f;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;

    private float _shootingTimer;
    private Transform _transform;

    private float DistanceToPlayer => Vector3.Distance(_player.position, _transform.position);

    private void Awake() => 
        _transform = transform;

    private void Update()
    {
        if (DistanceToPlayer > _stopDistance)
            _agent.SetDestination(_player.position);
        else
            _agent.SetDestination(transform.position);

        if (DistanceToPlayer > _shootingRange)
            return;

        if (_shootingTimer <= 0f)
        {
            Shoot();
            _shootingTimer = _shootingInterval;
        }
        else
        {
            _shootingTimer -= Time.deltaTime;
        }
    }
}