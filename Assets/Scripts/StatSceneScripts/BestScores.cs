using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestScores : MonoBehaviour {
    public Text L2BestScore;
    public Text L3BestScore;
    public Text L4BestScore;
    public Text L5BestScore;
	
	// Update is called once per frame
	void Start () {
        L2BestScore.text = PlayerPrefs.GetInt("2").ToString();
        L3BestScore.text = PlayerPrefs.GetInt("3").ToString();
        L4BestScore.text = PlayerPrefs.GetInt("4").ToString();
        L5BestScore.text = PlayerPrefs.GetInt("5").ToString();
    }
}
