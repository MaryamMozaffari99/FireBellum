using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based uppon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("How far player moves horizontally")]
    [SerializeField] float xRange = 10f;
    [Tooltip("How far player moves vertically")]
    [SerializeField] float yRange = 7f; 
   
    [Header("Laser gun array")]
    [Tooltip("Add all player tuning here")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    [Header("Screen position based tuning")]
    [SerializeField] float controlYawFactor = -5f; 
    [SerializeField] float controlRollFactor = -20f;

 
    float xThrow , yThrow;

    void Start()
    {

    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation() 
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = xThrow * controlYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
         
     void ProcessTranslation() 
    {   
        xThrow = Input.GetAxis("Horizontal");
        //Debug.Log(xThrow + "LSVFKDVK");
        yThrow = Input.GetAxis("Vertical");
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3
        (clampedXPos, clampedYpos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }

    void SetLaserActive(bool isActive)
    {
       foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }
    }

}
