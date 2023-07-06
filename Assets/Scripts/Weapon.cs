using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float numberOfBullets = 12f;
    public TextMeshProUGUI bulletsText;
    private AudioSource weaponAudio;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public AudioClip triggerSound;

    private void Start()
    {
        bulletsText.text = "Bullets: " + numberOfBullets;
        weaponAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && numberOfBullets == 0)
        {
            weaponAudio.PlayOneShot(reloadSound, 1.0f);
            numberOfBullets = 12f;
        }

        bulletsText.text = "Bullets: " + numberOfBullets;

    }
    public void Fire()
    {
        if(numberOfBullets > 0)
        {
            weaponAudio.PlayOneShot(shotSound, 0.3f);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            numberOfBullets--;
        }
        else if(numberOfBullets == 0)
        {
            weaponAudio.PlayOneShot(triggerSound, 0.1f);
        }

    }

   
}
