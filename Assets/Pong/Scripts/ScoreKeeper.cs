using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text leftTextScore;
    [SerializeField] private Text rightTextScore;

    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;

    [SerializeField] private GameManager gameManager;


    private int leftScore = 0;

    private int rightScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    private void RefreshScore()
    {
        //update the scores on screen
        leftTextScore.text = leftScore.ToString();
        rightTextScore.text = rightScore.ToString();
    }
    public void AddScore(Goal scoringSide)
    {
        if (scoringSide == leftGoal)
        {
            rightScore += 1;
            //if score is even make it yellow
            if (rightScore % 2 == 0)
            {
                rightTextScore.color = UnityEngine.Color.yellow;
            }
            //otherwise make it blue
            else {
                rightTextScore.color = UnityEngine.Color.blue;
            }
        }

        else
        {
            leftScore += 1;
            //if score is even make it red
            if (leftScore % 2 == 0)
            {
                leftTextScore.color = UnityEngine.Color.red;
            }
            //otherwise make it green
            else {
                leftTextScore.color = UnityEngine.Color.green;
            }
        }
        RefreshScore();
    }
}
