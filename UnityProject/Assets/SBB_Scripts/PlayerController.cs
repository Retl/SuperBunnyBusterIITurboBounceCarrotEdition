using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchBeganSingle(Touch touch)
    {
        //This executes when the user first taps a single finger to their screen.


    }

    void OnTouchMovedSingle(Touch touch)
    {
        //This executes when the user moves a single finger to their screen, even if they just released one or more.


    }

    void OnTouchReleaseExtra(Touch touch)
    {
        //This executes when the user releases a finger that is not their single touch.


    }
}
