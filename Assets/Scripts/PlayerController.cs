using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool hasKey = false;
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameObject graphics;
    public TextMeshProUGUI keysText;
    public int numberOfKeys = 0;
    
    Vector2 moveDirection;
    Vector2 mousePosition;

    [Header("MyAnimations")]
    private Animator animator;
    private AudioSource playerAudio;
    public AudioClip[] stepSounds;
    


    private void Start()
    {
        animator = graphics.GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        keysText.text = "Keys: " + numberOfKeys;

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        if(moveX != 0 || moveY != 0)
        {
            animator.SetBool("playerMove", true);

        }
        else
        {
            animator.SetBool("playerMove", false);
        }


        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (hasKey)
        {
            numberOfKeys = 1;
            keysText.text = "Keys: " + numberOfKeys;
        }
        
        StepSound();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }

    public int index;

    public void StepSound()
    {
        index = 1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            
                playerAudio.clip = stepSounds[index];
                playerAudio.enabled = true; 
            
        }
        else
        {
           
            playerAudio.enabled = false;
        }

    }
    
}
