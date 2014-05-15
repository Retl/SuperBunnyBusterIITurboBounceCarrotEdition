using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    public GameObject Player;
    public PlayerController p;

    public GameObject MoveMarkerTemplate;
    public GameObject MoveMarker;
    public BAD b;


    public float horizontalInput;
    public float verticalInput;

    //This stuff keeps track of what all the input

    // Use this for initialization
    void Start()
    {
        //Get a reference to the player's playerscript.
        if (Player != null)
        {
            p = Player.GetComponent<PlayerController>();
            
        }

        //Get a reference to the MoveMarker's movescript. If it isn't found, make one.
        if (MoveMarker == null)
        {
            MoveMarker = GameObject.FindGameObjectsWithTag("MoveMarker")[0];
            if (MoveMarker == null)
            {
                //We weren't pre-assigned a MoveMarker and weren't able to find one, either. Make one.
                if (MoveMarkerTemplate != null) {Instantiate(MoveMarkerTemplate);}
            }
            
        }
        //Either we found a MoveMarker, or we made one. Now set the script.
        b = MoveMarker.GetComponent<BAD>();
    }
    
    // FixedUpdate is called once per physics update, and is consistant between systems.
    void FixedUpdate()
    {

        ///<summary>This is the section where we deal with all of the input to be done when the Fire1/Jump button is pressed.</summary>
        if (Input.GetButtonDown("Fire1"))
        {  
            if (p != null)
            {
                p.Jump();
                print("Tapped at: " + Input.mousePosition.ToString());
                
            }
        }

        ///<summary>This is the section where we deal with all of the input to be done when the Fire1/Jump button is released.</summary>
        if (Input.GetButtonUp("Fire1"))
        {  
            if (p != null)
            {
                //If p has a method to make it immediately cancel ascention and start dropping, now would probably be a good time to call it.
                
            }
        }

        //What to do when the Horizontal axis is tilted one way or the other.
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput != 0)
        {
            if (p != null)
            {
                p.MoveHorizontal(horizontalInput);
            }
        }

        //What to do when the Vertical axis is tilted one way or the other.
        verticalInput = Input.GetAxis("Vertical");
        
        if (verticalInput != 0)
        {
            if (p != null)
            {
                //p.MoveVertical(verticalInput);
            }
        }

        //Handle the mouse input specifically. Maybe allow customizing this? I dunno.
        if (Input.GetButtonDown("Tap"))
        {
            //Stub.
            Vector3 screenPos = Input.mousePosition;
            Vector3 result;
            Ray tempRay = Camera.main.ScreenPointToRay(screenPos);
            result = tempRay.GetPoint(9.0f);
            result = new Vector3(result.x, result.y, 0);

            print("Tapped at: " + Input.mousePosition.ToString());
            print("Corresponds to: " + result.ToString());

            if (b != null) 
            {
                b.gameObject.SetActive(true); 
                b.JumpToPosition(result);
            }
        }
    }
}
