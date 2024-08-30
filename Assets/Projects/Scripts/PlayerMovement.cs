using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float Radius = 0.3f;
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 7.0f;
    [SerializeField] private LayerMask _groundLayers; 

    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void Update()
    {       
        float movementX = Input.GetAxis(Horizontal) * _speed;
        float movementZ = Input.GetAxis(Vertical) * _speed;

        Vector3 movement = _transform.right * movementX + _transform.forward * movementZ;
        Vector3 newPosition = _rigidbody.position + movement * Time.deltaTime;

        _rigidbody.MovePosition(newPosition);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded() =>
        Physics.CheckSphere(_transform.position, Radius, _groundLayers, QueryTriggerInteraction.Ignore);
}
