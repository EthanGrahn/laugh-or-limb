using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreboardController : MonoBehaviour
{
    public TextMeshProUGUI board;
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EditScoreBoard(float addScore)
    {
        EditBoard(addScore);
    }

    void EditBoard(float addScore)
    {
        score += addScore;
    }

    // Update is called once per frame
    void Update()
    {
        board.text = "Score: " + score.ToString();

        if (Input.GetKeyDown(KeyCode.L))
        {
            EditBoard(25);
        }
    }
}
