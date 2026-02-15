using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketCounter : MonoBehaviour
{

    [Header("Dynamic")]
    public int baskets = 4;

    private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Baskets Left: " + baskets.ToString("#,0");
    }
}
