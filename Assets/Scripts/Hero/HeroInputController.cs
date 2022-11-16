using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    //swerveınputsystem
    [SerializeField] private float horizontalValue;//sserilizefield sil
    public float HorizontalValue {
        get { return horizontalValue;}
    }

    private void HandleHeroHorizontalInput(){
        if(Input.GetMouseButton(0)){
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleHeroHorizontalInput();
    }
}
