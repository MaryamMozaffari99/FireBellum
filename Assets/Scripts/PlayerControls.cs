using UnityEngine;
//using UnityEngine.InputSystem; 

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] InputAction movement; 
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f; /*-5 to 5*/
    [SerializeField] float yRange = 3.5f; /*-5 to 5*/


    void Start()
    {

    }

    //New Input Sys
    //void OnEnable()
    //{
    //    movement.Enable();   
    //}
    //void OnDisable()
    //{
    //    movement.Disable();
    //}
    //New Input Sys


    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        //Debug.Log(xThrow + " HOOOR");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed; 
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3
        (clampedXPos, clampedYpos, transform.localPosition.z);


        //transform.l ocalPosition = new Vector3
        //(transform.localPosition.x,
        //transform.localPosition.y,
        //transform.localPosition.z);


        //New Input Sys
        //Note : to use New Input Sys You have to install Input New Sys Package
        //Into Player Section in the project Settings change the Active Handling to Both or Input Sys (New)
        //in the movement we created we selected 2d Vector X & Y
        //Add WASD



        //float horizontalThrow = movement.ReadValue<Vector2>().x;
        //Debug.Log(horizontalThrow  + "Hor");
        //float verticalThrow = movement.ReadValue<Vector2>().y;
        //Debug.Log(verticalThrow + "ver");



        //New Input Sys
    }
}
