using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{

    [Header("Dynamic")]
    static private int _ROUND = 1;

    // private int tScore = 1000;

    public ScoreCounter scoreCounter;
    static private Text _UI_TEXT;

    // Start is called before the first frame update
    void Start()
    {
        _UI_TEXT = GetComponent<Text>();
        ROUND = 1;
    }

    void Update()
    {
        if (_UI_TEXT != null)
        {
            _UI_TEXT.text = "Round: " + _ROUND.ToString("#,0");
        }
    }

    static public int ROUND
    {
        get { return _ROUND; }
        private set
        {
            _ROUND = value;
        }
    }

    static public void NEW_ROUND()
    {
        ROUND++;
    }
}
