using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    private const int SCORE_OF_RED_TANK = 1;
    private const int SCORE_OF_YELLOW_TANK = 3;
    private const int SCORE_OF_GREEN_TANK = 4;
    private const int SCORE_OF_BIG_RED_TANK = 5;
    private int scoreTotal = 0;
    [SerializeField] private TextMeshProUGUI _score;
    public void updateScore(float checkHealth)
    {
        if (checkHealth == 1)
        {
            scoreTotal = scoreTotal + SCORE_OF_RED_TANK;
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            _score.text = scoreSring;
        }
        else if(checkHealth == 2)
        {
            scoreTotal = scoreTotal + SCORE_OF_YELLOW_TANK;
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            _score.text = scoreSring;
        }
        else if(checkHealth == 3){
            scoreTotal = scoreTotal + SCORE_OF_YELLOW_TANK;
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            _score.text = scoreSring;
        }
        else if(checkHealth == 4){
            scoreTotal = scoreTotal + SCORE_OF_GREEN_TANK;
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            _score.text = scoreSring;
        }
    }
}
