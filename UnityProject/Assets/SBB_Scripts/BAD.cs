using UnityEngine;
using System.Collections;

public class BAD : MonoBehaviour
{
    string theString;
    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch tempTouch = Input.GetTouch(0);
            Vector3 temp = camera.ScreenToWorldPoint(new Vector3(tempTouch.position.x, tempTouch.position.y, 0.0f));
            //Vector3 temp = ScreenPositionToWorldPosition(tempTouch.position);
            transform.position = temp;
            theString = tempTouch.position.ToString();
        }
	
    }

    void OnGUI()
    {
				
        GUI.Label(new Rect(0, (Screen.height / 4), (Screen.width / 4), (Screen.height / 4)), "Stuff: " + theString);
    }

		
    private Vector3 ScreenPositionToWorldPosition(Vector2 screenPos)
    {
        Vector3 result;
        Ray tempRay = camera.ScreenPointToRay(screenPos);
        result = tempRay.GetPoint(9.0f);
        return result;
    }
}


	
