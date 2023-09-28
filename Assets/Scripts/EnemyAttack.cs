using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    private GameObject player;
    private HealthController healthController;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       healthController = player.GetComponent<HealthController>(); 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if(collision.gameObject == player)
        {
            healthController.TakeDamage(_damageAmount);
        }
    }
}
