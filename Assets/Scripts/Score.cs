using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (scoreText != null)
        {
            scoreText.text = GameManager.scoreHistory[gm.levelNumber].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
