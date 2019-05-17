using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserInputManager : MonoBehaviour
{

/// --------------------------- DECLARATIVE --------------------------------- ///

    // ------------ Easy Class Access ------------- //
	public static UserInputManager instance;

    // ------------ Mouse Input variables ------------- //
    public bool click = false; //Self-explanatory
    private Vector3 lastPosition = Vector3.zero; //Last stored position
    Vector3 mouseDelta = Vector3.zero; //Difference of mouse positions
    float mouseXAxisDelta = 0f; //Difference of mouse position on X Axis
    public float negativeMouseThreshold; //Set via Inspector
    public float positiveMouseThreshold; //Set via Inspector
    public float mouseSpeed = 0f; //Self-explanatory
    float timeDelta = 0f; //Unity's normalized time relative to framerate
    public float mouseFromCenter; //Distance of mouse from screen center (along X Axis only)

    // ------------ UI Screens ------------- //
    public GameObject[] screens; //Array of Movie Screens
    public bool inMovie = false; //Currently seeing Movie Screen



/// --------------------------- IMPERATIVE --------------------------------- ///

    private void Awake() {

		instance = this; //Tells other classes where this class is located
		
	}

    void Update()
    {

        //Calculates the speed of mouse movements along the X Axis, in order to accelerate UI horizontal scroll accordingly
        mouseDelta = Input.mousePosition - lastPosition;
        timeDelta = Time.deltaTime;
        mouseXAxisDelta = mouseDelta.x;
        mouseSpeed = mouseXAxisDelta / timeDelta;
        lastPosition = Input.mousePosition;

        //Calls function to calculate mouse distance from screen center
        MousePositionFromCenter(lastPosition);

        //Checks if user is clicking
        if (Input.GetMouseButton(0)){
            click = true;
        }
        else
        {
            click = false;
        }

    }

    //Calculates the distance from last mouse position to screen center, in order to stop scrolling when mouse is centered
    void MousePositionFromCenter (Vector3 lastPosition)
    {

        mouseFromCenter = lastPosition.x - Screen.width/2;

    }

    //Receives input from Movie Thumbnail buttons
    public void ButtonInput (int buttonNumber) {

        inMovie = true;

        for (int i = 0; i < screens.Length; i++) {
            screens[i].transform.gameObject.SetActive (false);
        }

        if (screens[buttonNumber].transform.gameObject != null)
        {
            screens[buttonNumber].transform.gameObject.SetActive (true);
        }
        else
        {
            inMovie = false;
        }

    }
}
