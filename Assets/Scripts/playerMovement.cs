using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField]float health = 100;
    public CardDisplay UI;

    [SerializeField] float moveSpeed;
    public Vector2 inputDirection,lookDirection;
    Animator anim;

    private Vector3 touchStart, touchEnd;
    public Image dpad;
    public Button attackButton;

    private Touch touchPoint;
    public float dPadRad;
    PlayerInput _pI;
    InputAction moveAction;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);

        _pI = GetComponent<PlayerInput>();
        moveAction = _pI.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls


        calculateDesktopInputs();

        //calculateMobileInput();

        //calculateTouchInput();

        //sets up the animator
        animationSetup();

        //moves the player
        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);
    }


    void calculateDesktopInputs()
    {
        /* float x = Input.GetAxisRaw("Horizontal");
         float y = Input.GetAxisRaw("Vertical");

         inputDirection = new Vector2(x, y).normalized;*/
        inputDirection = moveAction.ReadValue<Vector2>();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

    }


    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.1f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", lookDirection.x);
        anim.SetFloat("inputY", lookDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }
    
    public bool touchoverbutton(Button button)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(), Input.mousePosition, null);
    }

/*
    void calculateMobileInput()
    {
        //first version got checked each frame, new is per click 
        //bool touchOverAttackButton = RectTransformUtility.RectangleContainsScreenPoint(attackButton.GetComponent<RectTransform>(), Input.mousePosition, null);

        if (Input.GetMouseButton(0) && !touchoverbutton(attackButton))
        {
            dpad.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition;
            }
            touchEnd = Input.mousePosition;
            float x = touchEnd.x - touchStart.x;
            float y = touchEnd.y - touchStart.y;

            inputDirection = new Vector2(x, y).normalized;
            if((touchEnd - touchStart).magnitude > dPadRad)
            {
                dpad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRad;

            }
            else
            {
                dpad.transform.position = touchEnd;
            }
        }
        else
        {
            inputDirection = Vector2.zero;
            dpad.gameObject.SetActive(false);
        }
    }

    void calculateTouchInput()
    {
        if (Input.touchCount > 0 && !touchoverbutton(attackButton))
        {
            touchPoint = Input.GetTouch(0);
            dpad.gameObject.SetActive(true);

            if (touchPoint.phase == TouchPhase.Began)
            {
                touchStart = Input.mousePosition;
            }
            else if(touchPoint.phase == TouchPhase.Moved || touchPoint.phase == TouchPhase.Ended)
            {
                touchEnd = Input.mousePosition;
                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y;

                inputDirection = new Vector2(x, y).normalized;
                if ((touchEnd - touchStart).magnitude > dPadRad)
                {
                    dpad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRad;

                }
                else
                {
                    dpad.transform.position = touchEnd;
                }
            }
        }           
        else
        {
            inputDirection = Vector2.zero;
            dpad.gameObject.SetActive(false);
        }
    }
*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            UI.gameOvermenu();
        }
        if(collision.tag == "HealthPot")
        {
            Heal(50);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "PoisonPot")
        {
            Damage(50);
            Destroy(collision.gameObject);
        }
    }
    public void Heal(float healamount)
    {
        health += healamount;
    }
    public void Damage(float damamount)
    {
        health -= damamount;
    }
}
