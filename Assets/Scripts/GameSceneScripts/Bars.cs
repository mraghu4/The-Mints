using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bars : MonoBehaviour {

    public Text Score;
    public ParticleSystem blast;

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor")
                  == GetComponent<Renderer>().material.GetColor("_EmissionColor")) {
            Destroy(coll.gameObject);
            Game.SCORE++;
            Score.text = Game.SCORE.ToString();
        } else {
            Destroy(coll.gameObject);
            blast.startColor = coll.gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
            blast.transform.position = coll.gameObject.transform.position;
            blast.gameObject.SetActive(true);
            StartCoroutine(Sleep(1.0f));
            
        }

        if (Game.SCORE % 10 == 0  && Game.SCORE > 0 && Game.SPEED <= Game.MAX_SPEED) {
            Game.SPEED++;
            if (Game.GAP > Game.MIN_GAP)
            Game.GAP -= 0.5f;
        }
    }

    IEnumerator Sleep (float sec)   {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("GameOverScene");
    }
}
