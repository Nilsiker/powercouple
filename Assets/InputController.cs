using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    PlayerController pc;
    
    MainControls controls;

    void Awake(){
        controls = new MainControls();
        pc = GetComponent<PlayerController>();

        controls.Player.Move.performed += (ctx) => pc.SetMove(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed += (ctx) => pc.Jump();
        controls.Player.Move.canceled += (ctx) => pc.SetMove(ctx.ReadValue<Vector2>());
        controls.Player.RotateCamera.performed += (ctx) => pc.RotateCamera(ctx.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}
