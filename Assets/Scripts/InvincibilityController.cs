using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvicibility(float invincibilityDuration)
    {
        StartCoroutine(InvicibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvicibilityCoroutine(float invincibilityDuration)
    {
        _healthController.isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _healthController.isInvincible = false;
    }


}
