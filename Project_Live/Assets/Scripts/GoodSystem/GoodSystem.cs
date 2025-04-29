using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodSystem : MonoBehaviour
{
    [Header("いいね数のテキスト")]
    [SerializeField] TextMeshProUGUI goodText;
    int goodNum;
    public int GoodNum { get { return goodNum; } set { goodNum = value; } }

    // Start is called before the first frame update
    void Start()
    {
        goodNum = 0;
        //goodText.text = goodNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        goodText.text = goodNum.ToString();
        Debug.Log(goodNum);
    }
}
