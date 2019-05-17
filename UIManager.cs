using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

/// --------------------------- DECLARATIVE --------------------------------- ///

    // ------------ Easy Class Access ------------- //
	public static UIManager instance;

    // ------------ Scroll UI variables ------------- //
    public GameObject scrollView;
    ScrollRect scrollRect;
    RectTransform scrollViewTransform;
    public GameObject content;

    // ------------ Scroll UI variables ------------- //
    public Vector2 rightVector = new Vector2(1,0);
    public Vector2 leftVector = new Vector2(-1,0);
    public float thrust = 10.0f;
    private Vector2 screenBounds;

    public BoxCollider2D contentColliderLeft;
    public BoxCollider2D contentColliderRight;
    public BoxCollider2D leftCollider;
    public BoxCollider2D rightCollider;


    private void Awake() {

		instance = this;
		
	}

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = scrollView.transform.GetComponent<ScrollRect>();

        scrollViewTransform = scrollView.transform.GetComponent<RectTransform>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {

        if (UserInputManager.instance.click == true) {
            scrollRect.enabled = false;
        } else {
            scrollRect.enabled = true;
        }
         
        if (UserInputManager.instance.mouseFromCenter < -100 || UserInputManager.instance.mouseFromCenter > 100)
        {

            if (UserInputManager.instance.mouseSpeed <= UserInputManager.instance.negativeMouseThreshold)
            {
                content.GetComponent<Rigidbody2D>().AddForce (leftVector*thrust, ForceMode2D.Impulse);

                if (UserInputManager.instance.inMovie == true)
                {
                    UserInputManager.instance.ButtonInput(25);
                }
            }
            else if (UserInputManager.instance.mouseSpeed >= UserInputManager.instance.positiveMouseThreshold)
            {
                content.GetComponent<Rigidbody2D>().AddForce (rightVector*thrust, ForceMode2D.Impulse);

                if (UserInputManager.instance.inMovie == true)
                {
                    UserInputManager.instance.ButtonInput(25);
                }
            }

        }
        else
        {
            content.GetComponent<Rigidbody2D>().Sleep();
        }
        
    }
} 
