//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelHandle : MonoBehaviour {

    public static int LEVEL=2;
    public static Color[] color = new Color[5];
    private GameObject cross1;
    private GameObject cross2;
    private GameObject trngl1;
    private GameObject trngl2;
    private GameObject trngl3;
    private GameObject box1;
    private GameObject box2;
    private GameObject box3;
    private GameObject box4;
    private GameObject circle1;
    private GameObject circle2;
    private GameObject circle3;
    private GameObject circle4;
    private GameObject circle5;

    // Use this for initialization
    void Start () {
        cross1 = GameObject.Find("CrossF");
        cross2 = GameObject.Find("CrossB");
        trngl1 = GameObject.Find("Triangle1");
        trngl2 = GameObject.Find("Triangle2");
        trngl3 = GameObject.Find("Triangle3");
        box1 = GameObject.Find("Box1");
        box2 = GameObject.Find("Box2");
        box3 = GameObject.Find("Box3");
        box4 = GameObject.Find("Box4");
        circle1 = GameObject.Find("Circle1");
        circle2 = GameObject.Find("Circle2");
        circle3 = GameObject.Find("Circle3");
        circle4 = GameObject.Find("Circle4");
        circle5 = GameObject.Find("Circle5");

        SetLevel(LEVEL);
	}

    public void SetLevel(int level) {
        LEVEL = level;
        deactivateAllGameObj();
        SetRandomColorsToArray();
        switch (level) {
            case 2:
                cross1.GetComponent<Renderer>().material.SetColor("_EmissionColor",color[0]);
                cross2.GetComponent<Renderer>().material.SetColor("_EmissionColor",color[1]);
                cross1.SetActive(true);
                cross2.SetActive(true);
                break;
            case 3:
                trngl1.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[0]);
                trngl2.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[1]);
                trngl3.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[2]);
                trngl1.SetActive(true);
                trngl2.SetActive(true);
                trngl3.SetActive(true);
                break;
            case 4:
                box1.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[0]);
                box2.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[1]);
                box3.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[2]);
                box4.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[3]);
                box1.SetActive(true);
                box2.SetActive(true);
                box3.SetActive(true);
                box4.SetActive(true);
                break;
            case 5:
                circle1.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[0]);
                circle2.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[1]);
                circle3.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[2]);
                circle4.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[3]);
                circle5.GetComponent<Renderer>().material.SetColor("_EmissionColor", color[4]);
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                break;
        }
        
    }

    private void deactivateAllGameObj() {
        cross1.SetActive(false);
        cross2.SetActive(false);
        trngl1.SetActive(false);
        trngl2.SetActive(false);
        trngl3.SetActive(false);
        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
        box4.SetActive(false);
        circle1.SetActive(false);
        circle2.SetActive(false);
        circle3.SetActive(false);
        circle4.SetActive(false);
        circle5.SetActive(false);
    }

    public void loadScene(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }

    private void SetRandomColorsToArray() {
        Color[] clrs = { Color.HSVToRGB(207/360f,209/255f,233/255f),   //Blue
                         Color.HSVToRGB(180/360f,223/255f,185/255f),   //cyan
                         Color.HSVToRGB(153/360f,153/255f,153/255f),   //olive green
                         Color.HSVToRGB(52/360f,255/255f,255/255f),    //yellow
                         Color.HSVToRGB(330/360f,249/255f,128/255f),   //Maroon
                         Color.HSVToRGB(292/360f,242/255f,159/255f),   //purple
                         Color.black,
                         Color.red
                       };
        for (int i=0; i<5;) {
            Color clr = clrs[(int)Random.Range(0.0f,7.9f)];
            if(System.Array.IndexOf(color,clr) <0) {
                color[i] = clr;
                i++;
            }
        }
    }


}
