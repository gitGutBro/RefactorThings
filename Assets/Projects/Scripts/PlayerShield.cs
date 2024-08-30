using System.Collections;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private const KeyCode ActivateShield = KeyCode.E;

    [SerializeField] private float _cooldownDelay;
    [SerializeField] private PlayerHealth _health;

    private readonly WaitForSeconds _activateTime = new (3f);

    private float _cooldown;

    private bool CanActivate => Time.time >= _cooldown;

    private void Update()
    {
        if (Input.GetKeyDown(ActivateShield))
        {
            if (CanActivate == false)
                return;

            _cooldown = Time.time + _cooldownDelay;

            StartCoroutine(Activate());
        }
    }

    private IEnumerator Activate()
    {
        print("Shield activated!");
        _health.SetShieldState(true);

        yield return _activateTime;

        _health.SetShieldState(false);
        print("Shield deactivated!");
    }
}