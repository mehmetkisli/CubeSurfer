using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private HeroInputController heroInputController;
    public float forwardMovementSpeed;
    public float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValıe;


    private float newPositionX;


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHorizontalMovement();
    }

    private void SetHeroForwardMovement(){
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }
    private void SetHorizontalMovement(){
        newPositionX = transform.position.x + heroInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValıe,horizontalLimitValıe);
        transform.position = new Vector3(newPositionX, transform.position.y,transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
