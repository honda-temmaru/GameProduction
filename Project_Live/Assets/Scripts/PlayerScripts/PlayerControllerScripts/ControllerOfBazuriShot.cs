using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerOfBazuriShot : MonoBehaviour
{
    [SerializeField] BazuriShot bazuriShot;
    public void CallBazuriShot(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        bazuriShot.TryBazuriShot(); //バズりショットの呼び出し
    }
}
