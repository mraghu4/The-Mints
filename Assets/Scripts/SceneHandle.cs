using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandle : MonoBehaviour {
    public string SceneOnEscape;

    // Update is called once per frame
    void Update()  {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneOnEscape);
    }
}
