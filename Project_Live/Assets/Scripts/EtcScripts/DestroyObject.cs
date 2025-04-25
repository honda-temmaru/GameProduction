using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬ÒFŒKŒ´

public class DestroyObject : MonoBehaviour
{
    [Header("Á–Å‚·‚é‚Ü‚Å‚ÌŠÔ")]
    [SerializeField] float destroyDelay = 3f;

    void Start()
    {
        Destroy(this.gameObject, destroyDelay);
    }
}
