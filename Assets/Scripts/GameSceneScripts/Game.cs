using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour {

    private GameObject bar1;
    private GameObject bar2;
    private GameObject bar3;
    private GameObject bar4;
    private GameObject bar5;
    public GameObject dropBox;
    public GameObject pauseButton;
    public GameObject playButton;
    public GameObject pauseText;

    private int LEVEL = LevelHandle.LEVEL;
    public static int SCORE = 0;
    public static float SPEED = 5;       //spped multiplyer of falling objs
    public static int MAX_SPEED = 10;     // maximum speed multiplyer
    public static float GAP = 4.0f;      // sleep between spawning of falling objs
    public static float MIN_GAP = 1.0f;  // minimum sleep allowed between two spawns
    private float maxWidth;
    private float localTimeScale;        // to store TimeScale & restore when unpaused
    public static bool PAUSED = false;

    private Color[] clrs;
    GameObject[] bars;

    
       


    // Use this for initialization
    void Start () {
        bar1 = GameObject.Find("Bar1");
        bar2 = GameObject.Find("Bar2");
        bar3 = GameObject.Find("Bar3");
        bar4 = GameObject.Find("Bar4");
        bar5 = GameObject.Find("Bar5");

        playButton.SetActive(false);
        pauseButton.SetActive(true);
        localTimeScale = Time.timeScale;
        SCORE = 0;
        SPEED = 3;
        GAP = 4.0f;

        clrs = LevelHandle.color;
        bars =new GameObject[]{bar1, bar2, bar3, bar4, bar5 };
        ActivateBars();
        setSpawnRanges();
        StartCoroutine(StartGame());
       
    }

    //create Bars based on level number & add color to them
    private void ActivateBars() {
        //start from 5th bar, disable till LEVEL+1 bar
        for (int i=4; i >= LEVEL; i-- ) {
            bars[i].SetActive(false);
        }

        //set colrs to rest
        for (int i=0; i<=LEVEL-1; i++){
            bars[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", clrs[i]);
        }
    }

    //find allowd X cordinates of falling objs 
    private void setSpawnRanges() {
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height,0);
        Vector3 targetWidth = Camera.main.ScreenToWorldPoint(upperCorner);
        float mintWidth = dropBox.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - (2*mintWidth);
    }

    //spawn the Mints
    IEnumerator StartGame() {
        yield return new WaitForSeconds(2.0f);
        while(true) {
            //spawn mints
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-maxWidth,maxWidth), 6, 0);
            GameObject go = (GameObject)Instantiate(dropBox, spawnPosition,Quaternion.identity);
            go.GetComponent<Renderer>().material.SetColor("_EmissionColor", clrs[UnityEngine.Random.Range(0,LEVEL)]);
            go.SetActive(true);
            yield return new WaitForSeconds(GAP);
            
        }
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pauseText.SetActive(true);
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        PAUSED = true;
    }

    public void UnPauseGame() {
        Time.timeScale = localTimeScale;
        pauseText.SetActive(false);
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        PAUSED = false;
    }

}
