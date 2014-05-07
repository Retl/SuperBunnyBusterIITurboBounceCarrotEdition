using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    string theString = "Nothinghere";
    const float MINDISTANCEFROMMARKER = 10f;
    const float MAXDISTANCEFROMSTART = 100.0f;
    float jumpSpeed = 32f;
    float moveSpeed = 8.0f;
    float maxSpeed = 16.0f;
    public GameObject myMarker;
    Vector3 startPosition;
    Quaternion startRotation;
    public GameObject badContainer;
    public float theVelocityMagnitude;
    public bool isJumping = false;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    
    // Update is called once per frame
    void Update()
    {
        theVelocityMagnitude = rigidbody2D.velocity.magnitude;
        //Let the input handler take care of this, but know that this behavior is an option. - Moore
        /*
        if (Input.GetButton("Fire1"))
        {  
            Jump();
        }
        */


        //FollowMoveMarker();

        if (Vector3.Distance(transform.position, startPosition) > MAXDISTANCEFROMSTART)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
            /*
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;

            }
            */
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
        TouchHandler bad = badContainer.GetComponent<TouchHandler>();
        GUI.Label(new Rect(0, 0, (Screen.width / 4), (Screen.height / 4)), theString + " Count: " + bad.TouchCount);
    }

    //Player Action Methods.
    public void Jump()
    {
        if (isJumping)
        {
            Burst();
        } else
        {
            if (rigidbody2D != null)
            {
                if (rigidbody2D.velocity.y < 0)
                {
                    rigidbody2D.velocity -= new Vector2(0, rigidbody2D.velocity.y);
                }
                rigidbody2D.AddForce(Vector2.up * jumpSpeed * 10);
            } else
            {
                transform.position += transform.up * jumpSpeed * 10;
            }
        }
    }

    /// <summary>
    /// Make this script's hosting gameObject perform the burst attack. Lock on to the nearest target and zoom towards at a high speed.
    /// </summary>
    public void Burst()
    {

    }

    /// <summary>
    /// This method takes in a float 'amount' from -1.0f to 1.0f. 
    /// This amount is multiplied by the moveSpeed scalar and used to AddForce to this object's rigidbody2D (if it has one) right. 
    /// </summary>
    /// <param name="amount">Amount.</param>
    public void MoveHorizontal(float amount)
    {
        if (rigidbody2D != null)
        {
            rigidbody2D.AddForce(Vector2.right * moveSpeed * amount);
            if (rigidbody2D.velocity.magnitude > maxSpeed)
            {
                //If the player's current speed is faster than they are supposed to be able to move, clamp the speed down. Careful though, as this does include vertical speed.
                rigidbody2D.velocity = rigidbody2D.velocity.normalized * Mathf.Clamp(rigidbody2D.velocity.magnitude, -maxSpeed, maxSpeed);
            }
        }
    }

    public void MoveVertical(float amount)
    {
        //STUB.
        if (rigidbody2D != null)
        {
            rigidbody2D.AddForce(Vector2.up * moveSpeed * amount); //DELETEME - Moore
        }
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
