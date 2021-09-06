using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public Text Score;
    public Text BestScore;
    public string scene_name;
    
    // Use this for initialization
    void Start () {
        Score.text = Game.SCORE.ToString();
        int previous_high = PlayerPrefs.GetInt(LevelHandle.LEVEL.ToString());
        if ( previous_high < Game.SCORE)  {
            PlayerPrefs.SetInt(LevelHandle.LEVEL.ToString(),Game.SCORE);
            BestScore.text = "BEST\n"  + Game.SCORE.ToString();
        } else { 
            BestScore.text =  "BEST\n" + previous_high.ToString();
        }

    }

    public void Replay ()  {
        SceneManager.LoadScene(scene_name);
    }
}
