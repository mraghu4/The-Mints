using UnityEngine;
using System.Collections;

public class DropHandel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    void Update () {
        transform.Translate(new Vector2(0,-1) * Game.SPEED * Time.deltaTime);

    }

}
