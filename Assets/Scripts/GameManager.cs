using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemiesInScene;
    public int enemiesInstancesLimit;
    public int nextScene;
    public bool isTitleScene = false;
    public float numberOfKills = 0f;
    public TextMeshProUGUI killsText;
    private GameObject[] getCount;
    
    void Start()
    {
        if (isTitleScene == false)
        {

            killsText.text = "Kills: " + numberOfKills;
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();

        }
     
    }

    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesInScene = getCount.Length;
        if(isTitleScene == false)
        {
            killsText.text = "Kills: " + numberOfKills;
        }
        
    }

    public void RestartGame()
    {
        Invoke("MyLoadingRestartFunction", 1.5f);
    }

    void MyLoadingRestartFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartGame()
    {
        Invoke("MyLoadingStartFunction", 1.5f);
    }

    void MyLoadingStartFunction()
    {
        SceneManager.LoadScene(nextScene);

    }
}
