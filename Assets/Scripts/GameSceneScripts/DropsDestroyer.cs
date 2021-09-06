using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DropsDestroyer : MonoBehaviour {

    public string scene_name;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
        SceneManager.LoadScene(scene_name);
    }
}
