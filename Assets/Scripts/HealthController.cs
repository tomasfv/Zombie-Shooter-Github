using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public GameObject graphics;
    public GameObject gameOverUI;
    public GameObject Crosshair;

    private Animator animator;
    public AudioSource playerAudio;
    public AudioClip playerPainSound; 

    private void Start()
    {
        animator = graphics.GetComponent<Animator>();
        
    }

    public float remainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool isInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {
        if(_currentHealth == 0)
        {
            return;
        }

        if (isInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;
        OnHealthChanged.Invoke();
        playerAudio.PlayOneShot(playerPainSound);

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if(_currentHealth == 0)
        {
            animator.SetBool("playerDead", true);
            OnDied.Invoke();
            gameOverUI.SetActive(true);
            Crosshair.SetActive(false);
            Cursor.visible = true;
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if(_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;
        OnHealthChanged.Invoke();

        if(_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }
}
