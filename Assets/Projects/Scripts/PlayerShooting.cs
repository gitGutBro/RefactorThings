using UnityEngine;

public class PlayerShooting : ShootSystem
{
    private const string Fire = nameof(Fire);

    private void Update()
    {
        if (Input.GetButtonDown(Fire))
            Shoot();
    }
}