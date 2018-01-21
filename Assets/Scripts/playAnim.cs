using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnim : MonoBehaviour {


    swipeCTRL tCtrl;
    GameObject sarcough;
    GameObject movieQuad;
    float xPoz = 43.59f;
    float yOrg = 17.64f;
    // Use this for initialization
    void Start () {
        tCtrl = GameObject.Find("touchCTRL").GetComponent<swipeCTRL>();
        sarcough = GameObject.Find("Sarcougogus1").GetComponent<GameObject>();
        movieQuad = GameObject.Find("MoviePiece").GetComponent<GameObject>();

        movieQuad.transform.position = new Vector3(xPoz, yOrg, -10.2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void HandleAnim()
    {


        if(tCtrl.GetSwipeDirection()== swipe_direction.up) {
            movieQuad.transform.position = new Vector3(xPoz, 60f, -10.3f)*Time.deltaTime;
        }
        else if (tCtrl.GetSwipeDirection() == swipe_direction.down)
        {
            movieQuad.transform.position = new Vector3(xPoz, 60f, -10.3f) * Time.deltaTime;
        }
        else if (tCtrl.GetSwipeDirection() == swipe_direction.left)
        {
            
        }
        else if(tCtrl.PressedDown()==true){
            movieQuad.transform.position = new Vector3(xPoz, yOrg, 38.93f) * Time.deltaTime;
            movieQuad.transform.localScale = new Vector3(13.39433f, 17.64367f, 0.4814913f) * Time.deltaTime;
        }
    }
}
