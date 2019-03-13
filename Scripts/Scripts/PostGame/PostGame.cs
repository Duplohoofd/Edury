using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostGame : MonoBehaviour
{
    private TextMeshProUGUI pogingen;
    private TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        //PogingenScore in post game
        pogingen = GameObject.Find("PogingenText").GetComponent<TextMeshProUGUI>();
        pogingen.text = "Aantal Pogingen: " + PlayerPrefs.GetInt("Kansen");

        //Score in post game
        score = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        score.text = "Score: " + PlayerPrefs.GetInt("MemoryScore");
    }

}
