using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    private const int SCORE_OF_RED_TANK = 1;
    private int scoreTotal = 0;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private List<HealCharater> checkTankDestroyeds;
    // Update is called once per frame
    void Update()
    {
        foreach (var checkTankDestroyed in checkTankDestroyeds)
        {
            if (checkTankDestroyed.isDestroyedEnemies())
            {
                var addScore = scoreTotal + SCORE_OF_RED_TANK;
                Debug.Log(addScore);
                string scoreSring = string.Format("Score: {0}", addScore);
                _score.text = scoreSring;
            }
        }
    }
}
