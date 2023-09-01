using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoldenKey : MonoBehaviour
{
    public AudioSource keySound;
    public TextMeshProUGUI keyMessage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<PlayerController>().hasKey)
        {
            keySound.Play();
            other.gameObject.GetComponent<PlayerController>().hasKey = true;
            StartCoroutine(ShowMessage());
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public IEnumerator ShowMessage()
    {
        keyMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        keyMessage.gameObject.SetActive(false);

    }
}
