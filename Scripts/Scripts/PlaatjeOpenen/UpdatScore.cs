using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatScore : MonoBehaviour { 

    private TextMeshProUGUI scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
        scoreLabel.text = "Score: ";
    }

}
