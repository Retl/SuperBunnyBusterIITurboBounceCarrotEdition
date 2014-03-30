using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    string theString = "Nothinghere";
    const float MINDISTANCEFROMMARKER = 10f;
    const float MAXDISTANCEFROMSTART = 100.0f;
    float moveSpeed = 1.0f;

    public GameObject myMarker;

    Vector3 startPosition;
    Quaternion startRotation;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {  
            Jump();
        }


        FollowMoveMarker();

        if (Vector3.Distance(transform.position, startPosition) > MAXDISTANCEFROMSTART)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;

            }
        }
    }

    void OnTouchBeganSingle(Touch touch)
    {
        //This executes when the user first taps a single finger to their screen.
        theString = "First Touch Started";
        /*
        if (myMarker != null)
        {
            myMarker.transform.position = new Vector3(touch.position.x, myMarker.transform.position.y, myMarker.transform.position.z);
        }	
        */

    }

    void OnTouchMovedSingle(Touch touch)
    {
        //This executes when the user moves a single finger to their screen, even if they just released one or more.
        if (touch.deltaPosition.magnitude > 1.0f)
        {
            float temp = touch.deltaPosition.magnitude;
            theString = "Touch Moved: ";
        }

    }

    void OnTouchReleasedSingle(Touch touch)
    {
        //This executes when the user releases a finger that is not their single touch.
        theString = "Released all touches.";
        
    }

    void OnTouchReleaseExtra(Touch touch)
    {
        //This executes when the user releases a finger that is not their single touch.
        theString = "Released an extra touch.";
        //Just gonna jump for now. We'd probably want to have a method here that also handles attacking and whatnot.
        Jump();
        
    }

    void OnGUI()
    {
        TouchHandler bad = gameObject.GetComponent<TouchHandler>();
        GUI.Label(new Rect(0, 0, (Screen.width / 4), (Screen.height / 4)), theString + " Count: " + bad.TouchCount);
    }

    //Player Action Methods.
    void Jump()
    {
        /*if (rigidbody != null)
        {
            rigidbody.AddForce(transform.up * moveSpeed);
        } else
        {*/
        transform.position += transform.up * moveSpeed * 10;
        //}
    }

    void FollowMoveMarker()
    {
        /*GameObject theMarker = RevelUtils.FindClosestGameObjectWithTag(gameObject, "MoveMarker")*/
        ;
        GameObject theMarker = myMarker;
        if (theMarker != null /*&& RevelUtils.IsNotWithinDistanceThreshold(gameObject, theMarker, MINDISTANCEFROMMARKER)*/)
        {
            /*Vector3 temp = theMarker.transform.position - gameObject.transform.position;
            temp.z = 0;
            temp.Normalize();
            if (rigidbody != null)
            {

                rigidbody.AddForce(temp);
            } else
            {
                transform.position += temp;
            }*/
            if (transform.position.x > theMarker.transform.position.x)
            {
                transform.position -= (new Vector3(moveSpeed, 0, 0));
            } else if (transform.position.x < theMarker.transform.position.x)
            {
                transform.position += (new Vector3(moveSpeed, 0, 0));
            }

        }
    }

}
