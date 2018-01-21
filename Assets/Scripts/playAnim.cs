using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnim : MonoBehaviour {


    swipeCTRL tCtrl;
    GameObject sarcough;
    GameObject movieQuad;
    float xPoz = 43.59f;
    float yOrg = 17.64f;
    Camera mainCam;

    // Use this for initialization
    void Start () {
        tCtrl = GameObject.Find("touchCTRL").GetComponent<swipeCTRL>();
       //sarcough = GameObject.Find("Sarcougogus1");
       //sarcough.SetActive(false);
        movieQuad = GameObject.Find("MoviePiece");

        movieQuad.transform.position = new Vector3(xPoz, yOrg, -10.2f);
        mainCam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        HandleAnim();
	}

    bool StopedMoving = true;
    bool down = false;
    bool up = false;

    bool pressed = false;
    float StartTime = 0;

    void HandleAnim()
    {
        if(tCtrl.GetSwipeDirection() == swipe_direction.up)
        {
            up = true;
            StopedMoving = false;
            StartTime = Time.time;
        }
        else if (tCtrl.GetSwipeDirection() == swipe_direction.down)
        {
            down = true;
            StopedMoving = false;
            StartTime = Time.time;
            
        }
        else if (tCtrl.GetSwipeDirection() == swipe_direction.left)
        {
            
        }
        else if(tCtrl.PressedDown()==true){
            movieQuad.transform.position += new Vector3(0, 0, -38.93f) * Time.deltaTime;
            movieQuad.transform.localScale -= new Vector3(8.39433f, 8.64367f, 0.4814913f) * Time.deltaTime;
            //sarcough.SetActive(true);
        }
        
        if (!StopedMoving)
        {
            float EndTime = Time.time;
            float elapsed = EndTime - StartTime;
            if (elapsed > .5f)
            {
                StopedMoving = true;
                down = false;
                up = false;
            }
            float Yoffset = 0.0f;

            if (down)
            {
                Yoffset = -60f;
            }
            if (up)
            {
                Yoffset = 60f;
            }

            movieQuad.transform.position += new Vector3(0, Yoffset, 0) * Time.deltaTime;
            mainCam.transform.position += new Vector3(0, Yoffset, 0) * Time.deltaTime;
        }
    }
}
