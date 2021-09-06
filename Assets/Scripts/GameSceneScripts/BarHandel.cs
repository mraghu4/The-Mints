using UnityEngine;
using System.Collections;


public class BarHandel : MonoBehaviour {

    private Rigidbody2D rbd;
    
    
    // Update is called once per frame
    void Update() {

        if(Game.PAUSED)  {
            return;
        }

        if (Input.touchCount > 0) {
            Touch t = Input.GetTouch(0);
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            
            //if (t.phase == TouchPhase.Began) {
                if (hit.rigidbody != null) {
                    rbd = hit.rigidbody;
                } 
            //}

            //if (t.phase == TouchPhase.Moved) {
                //var cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
                Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, 0, 0));
                rbd.transform.position = new Vector2(v.x, rbd.position.y);
            //}

            if(t.phase == TouchPhase.Ended) {
                rbd = null;
            }

        }


        /*
        Vector2 MworldPoint;
        RaycastHit2D Mhit;
        Vector2 Ms = new Vector2(0.0f,0.0f);
        Vector2 Me = new Vector2(0.0f, 0.0f);
        Vector2 Md = new Vector2(0.0f, 0.0f);
        if (Input.GetMouseButtonDown(0))
        {
            MworldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Mhit = Physics2D.Raycast(MworldPoint, Vector2.zero);


            if (Mhit.rigidbody != null)
            {
                rbd = Mhit.rigidbody;
                Ms = new Vector2(Input.mousePosition.x, 0.0f);
            }
        }
            var McameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
            Debug.Log(McameraTransform);
            Me = new Vector2(Input.mousePosition.x, 0.0f);
            Vector3 Mv = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));
            rbd.transform.Translate(new Vector2(Mv.x, 0) * 5 * Time.deltaTime);
        */
        
    } //End of Updtae

}
