using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;
    
    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private int enemyHealth = 2;

    

    private Rigidbody2D _rigidBody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    public GameObject graphics;
    private Animator animator;

    public UnityEvent OnDied;

    private AudioSource zombieSound;




    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
        animator = graphics.GetComponent<Animator>();
        zombieSound = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth--;

            if(enemyHealth <= 0)
            {
                animator.SetBool("isDead", true);
                zombieSound.Play();
                _speed = 0;
                transform.position = new Vector2(transform.position.x, transform.position.y);
                OnDied.Invoke();
                Destroy(gameObject, 0.3f);
                //StartCoroutine(DestroyEnemy());

            }

        }   

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        //SetBounds();
        
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        
    }

    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;

        if(_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {
       

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidBody.SetRotation(rotation);

    }

    private void SetVelocity()
    {
        
       _rigidBody.velocity = transform.up * _speed;
        
    }

    //IEnumerator DestroyEnemy()
    //{
    //    animator.SetBool("isDead", true);
    //    zombieSound.Play();
    //    _speed = 0;
    //    transform.position = new Vector2(transform.position.x, transform.position.y);
    //    yield return new WaitForSeconds(0.3f);
    //    gameObject.SetActive(false);

    //}

}
