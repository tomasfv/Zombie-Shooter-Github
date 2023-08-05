using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillsCounter : MonoBehaviour
{
    public float numberOfKills = 0f;
    public TextMeshProUGUI killsText;

    // Start is called before the first frame update
    void Start()
    {
        killsText.text = "Kills: " + numberOfKills;
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = "Kills: " + numberOfKills;
    }
}
