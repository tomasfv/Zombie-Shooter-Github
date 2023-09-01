using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DoorSystem : MonoBehaviour
{
    private AudioSource doorSound;
    public AudioClip lockedDoorSound;
    public AudioClip openDoorSound;
    public TextMeshProUGUI closedDoorText;
    public TextMeshProUGUI victoryText;
    public int nextScene;
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<PlayerController>().hasKey)
        {
            doorSound.PlayOneShot(openDoorSound, 2.0f);
            StartCoroutine(VictoryMessage());
        }
        else if(other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<PlayerController>().hasKey)
        {
            doorSound.PlayOneShot(lockedDoorSound, 2.0f);
            StartCoroutine(ClosedDoorMessage());
            

        }
    }

        public IEnumerator ClosedDoorMessage()
        {
            closedDoorText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            closedDoorText.gameObject.SetActive(false);
        }
        public IEnumerator VictoryMessage()
        {
            victoryText.gameObject.SetActive(true);
            yield return new WaitForSeconds(5);
            victoryText.gameObject.SetActive(false);
            SceneManager.LoadScene(nextScene);

    }



}
