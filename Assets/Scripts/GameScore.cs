using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Mục tiêu của lớp: tính điểm khi người chơi tiêu diệt địch
public class GameScore : MonoBehaviour
{
    //Điểm cố định của Red Tank Enemy
    private const int SCORE_OF_RED_TANK = 1;
    //Điểm cố định của Yellow Tank Enemy
    private const int SCORE_OF_YELLOW_TANK = 3;
    //Điểm cố định của Green Tank Enemy
    private const int SCORE_OF_GREEN_TANK = 4;
    //Điểm cố định của Boss Tank Enemy
    private const int SCORE_OF_BOSS = 100;
    //Điểm tổng 
    private int scoreTotal = 0;
    //Lưu giữ UI chữ trong unity được dùng để hiển thị điểm trong game
    [SerializeField] private TextMeshProUGUI _score;
    //Hàm cập nhập điểm
    public void updateScore(float checkHealth)
    {
        //Nếu máu của địch bằng 1
        if (checkHealth == 1)
        {
            //Cộng điểm tổng với điểm Red tank enemy
            scoreTotal = scoreTotal + SCORE_OF_RED_TANK;
            //Tạo biến string lưu điểm của người chơi
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            //Tiến hành sửa đổi điểm trong game
            _score.text = scoreSring;
        }
        // //Nếu máu của địch bằng 2
        // else if(checkHealth == 2)
        // {
        //     //Cộng điểm tổng với yellow tank enemy
        //     scoreTotal = scoreTotal + SCORE_OF_YELLOW_TANK;
        //     string scoreSring = string.Format("Score: {0}", scoreTotal);
        //     _score.text = scoreSring;
        // }
        //Nếu máu của địch bằng 3
        else if(checkHealth == 3){
            //Cộng điểm tổng với điểm của Yellow tank enemy
            scoreTotal = scoreTotal + SCORE_OF_YELLOW_TANK;
            //Tạo biến string lưu điểm của người chơi
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            //Tiến hành sửa đổi điểm trong game
            _score.text = scoreSring;
        }
        //Nếu máu của địch bằng 4
        else if(checkHealth == 4){
            //Cộng điểm tổng với Green tank enemy
            scoreTotal = scoreTotal + SCORE_OF_GREEN_TANK;
            //Tạo biến string lưu điểm của người chơi
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            //Tiến hành sửa đổi điểm trong game
            _score.text = scoreSring;
        }
        //Nếu máu của địch bằng 100
        else if(checkHealth == 100){
            //Cộng điểm tổng với điểm của Boss tank enemy
             scoreTotal = scoreTotal + SCORE_OF_BOSS;
            //Tạo biến string lưu điểm của người chơi
            string scoreSring = string.Format("Score: {0}", scoreTotal);
            //Tiến hành sửa đổi điểm trong game
            _score.text = scoreSring;
        }
    }
}
