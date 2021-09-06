using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void loadScene(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }
}
