using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatControls : MonoBehaviour
{

    
    public InputActionAsset playerControls;
    public InputAction upLight, Heavy, UpHeavy,DownHeavy, DownLight ;

    public void awakeControls(){
        upLight = playerControls.FindAction("Up-Light");
        Heavy = playerControls.FindAction("Heavy");
        UpHeavy = playerControls.FindAction("Up-Heavy");    
        DownHeavy = playerControls.FindAction("Down-Heavy");
        DownLight = playerControls.FindAction("Down-Light");
    }

    public void enableControls(){
        upLight.Enable();
        Heavy.Enable();
        UpHeavy.Enable();
        DownHeavy.Enable();
        DownLight.Enable();
    }

    public void disableControls(){
        upLight.Disable();
        Heavy.Disable();
        UpHeavy.Disable();
        DownHeavy.Disable();
        DownLight.Disable();
    }


    
}
