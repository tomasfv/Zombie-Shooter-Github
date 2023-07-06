using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set;}

    [SerializeField]
    private float _playerAwarenessDistance;
    //[SerializeField]
    //private float _maxDistance;
    
    private Transform _player;

    
    void Awake()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        _player = FindObjectOfType<PlayerController>().transform;
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        } else
        {
            AwareOfPlayer = false;
        }

        //if(enemyToPlayerVector.magnitude > _maxDistance)
        //{
        //    Destroy(gameObject, 5.0f);
        //}
    }
}
