//ì¬Ò:›‘º

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentGet : MonoBehaviour
{
    GoodSystem goodSystem;
    GameObject goodsystem;

    bool getTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        goodsystem = GameObject.FindWithTag("GoodSystem");
        goodSystem= goodsystem.GetComponent<GoodSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (getTrigger)
            return;
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            goodSystem.GoodNum += 10;
            Debug.Log("ƒRƒƒ“ƒg‚ğæ“¾‚µ‚Ü‚µ‚½");
        }
    }
}
