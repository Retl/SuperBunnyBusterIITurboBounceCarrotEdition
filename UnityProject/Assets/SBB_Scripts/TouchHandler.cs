using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour
{

    //START OF DECLARATION SECTION
    const bool TESTING = true;
    protected System.Collections.Generic.List<Touch> activeTouches = new System.Collections.Generic.List<Touch>();
    string recorded;
    string actual;
    //END OF DECLARATION SECTION

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {

        //Get the state of current input.
        actual = "";
        recorded = "";

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch currentTouch = Input.GetTouch(i);
            actual += GetTouchInfo(currentTouch);
            int matchIndex = activeTouches.FindIndex(compMe => compMe.fingerId == currentTouch.fingerId);
            if (matchIndex < 0)
            { //If my current touch is not a recognized active touch (NONE of the contained touchIds match the current one)...
                //Add this touch to the list of active touches.
                activeTouches.Add(currentTouch);
            } else
            {
                //If I do recognize this touch, then make sure to update its contents.
                activeTouches [matchIndex] = currentTouch;
            }
        }

        //Do stuff with our known active touches.
        for (int i = 0; i < activeTouches.Count; i++)
        {
            Touch theTouch = activeTouches [i];

            //If there's only one touch...
            if (activeTouches.Count == 1)
            {
                //Move the marker. If we want this to be reusable, we shouldn't do this HERE so much as facilitate a method that will allow it elsewhere.

                if (theTouch.phase == TouchPhase.Began)
                {
                    BroadcastMessage("OnTouchBeganSingle", theTouch, SendMessageOptions.DontRequireReceiver);
                }

                if (theTouch.phase == TouchPhase.Moved)
                {
                    BroadcastMessage("OnTouchMovedSingle", theTouch, SendMessageOptions.DontRequireReceiver);
                }

                if (theTouch.phase == TouchPhase.Ended || theTouch.phase == TouchPhase.Canceled)
                {
                    BroadcastMessage("OnTouchReleasedSingle", theTouch, SendMessageOptions.DontRequireReceiver);
                }


            }


            if (theTouch.phase == TouchPhase.Ended || theTouch.phase == TouchPhase.Canceled)
            {
                //If the touch has ended or been canceled, we announce that it has been released, and then
                if (activeTouches.Count > 1)
                {
                    BroadcastMessage("OnTouchReleaseExtra", theTouch, SendMessageOptions.DontRequireReceiver);
                }

                //We remove it from the active touches and compensate for that in this loop.
                activeTouches.RemoveAt(i);
                i--;

                //The way this is currently, tapping with three fingers and releasing two should quickly do a jump and burst.
            }
        }

        //Inform all scripts on the same object as I am of what I have done.
    

        foreach (Touch c in activeTouches)
        {
            recorded += GetTouchInfo(c);
        }
    }

    //START OF ACCESSOR METHODS

    public int TouchCount
    {
        get { return activeTouches.Count;}
    }

    //END OF ACCESSOR METHODS


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

    void OnGUI()
    {
        if (TESTING)
        {
            GUI.Label(new Rect(0, (Screen.height / 2), (Screen.width / 4), (Screen.height / 4)), " Actual: " + actual);
            GUI.Label(new Rect(0, (Screen.height / 4 * 3), (Screen.width / 4), (Screen.height / 4)), " Recorded: " + recorded);
        }
    }

    string GetTouchInfo(Touch t)
    {
        string result = "";
        result += t.fingerId + ":[";
        result += t.phase + ", ";
        result += t.position.ToString() + ", ";
        result += t.tapCount;

        result += "];\n";
        return result;
    }
}
