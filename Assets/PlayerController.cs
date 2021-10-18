using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f, boostSpeed = 80f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed, activeBoostSpeed;
    public float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance; //mouseDistance is distance the mouse has from center of screen

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 2.5f;

    public Vector3 speed;
    private Vector3 lastPos;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        screenCenter.x = Screen.width / 2f;
        screenCenter.y = Screen.height / 2f;

        lastPos = transform.position;
        
    }
    
    
    void Update()
    {
       
        //Recording location of mouse
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
        

        //SHIP ROTATION
        rollInput = Mathf.Lerp(rollInput, Input.GetAxis("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookSpeed * Time.deltaTime, mouseDistance.x * lookSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);



        //SHIP MOVEMENT
        //Smooth translational movement with acceleration
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Mathf.Lerp(activeBoostSpeed, boostSpeed, boostAcceleration * Time.deltaTime);
            activeForwardSpeed = boostSpeed;
        }

        transform.position += (activeForwardSpeed * Time.deltaTime * transform.forward) + (activeStrafeSpeed * Time.deltaTime * transform.right) + (activeHoverSpeed * Time.deltaTime * transform.up);

    }

    private void FixedUpdate()
    {
        //Speedometer();
    }
    
    private void Speedometer()
    {
        if (lastPos != transform.position)
        {
            speed = transform.position - lastPos;
            speed /= Time.deltaTime;
            lastPos = transform.position;
        }
        else
        {
            speed = Vector3.zero;
        }
        print(speed.magnitude);
    }
}
