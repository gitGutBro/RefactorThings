using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const string AxisMouseX = "Mouse X"; 
    private const string AxisMouseY = "Mouse Y";

    private const float MinRotationX = -50f;
    private const float MaxRotationX = 50f;

    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private Transform _playerBody;

    private float _rotationX;
    private Transform _transform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rotationX = 0f;
        _transform = transform;
    }

    private void Update()
    {
        float mouseX = GetAxis(AxisMouseX);
        float mouseY = GetAxis(AxisMouseY);

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, MinRotationX, MaxRotationX);

        _transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    private float GetAxis(string mouse) =>
        Input.GetAxis(mouse) * _sensitivity * Time.deltaTime;
}