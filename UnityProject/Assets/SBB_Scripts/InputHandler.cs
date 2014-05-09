using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    public GameObject Player;
    public PlayerController p;

    public float horizontalInput;
    public float verticalInput;

    //This stuff keeps track of what all the input

    // Use this for initialization
    void Start()
    {
        if (Player != null)
        {
            p = Player.GetComponent<PlayerController>();
            
        }
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


    }
}
