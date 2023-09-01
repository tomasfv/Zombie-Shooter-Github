using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillsCounter : MonoBehaviour
{
    public float numberOfKills = 0f;
    public TextMeshProUGUI killsText;

    void Start()
    {
        killsText.text = "Kills: " + numberOfKills;
    }

    void Update()
    {
        killsText.text = "Kills: " + numberOfKills;
    }
}
