using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoccerGameController : MonoBehaviour
{
    public Text redScoreText;
    public Text blueScoreText;

    int _redScore = 0;
    int _blueScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoal(GateColor gateColor)
    {
        if (gateColor == GateColor.RED)
        {
            _redScore++;

            redScoreText.text = _redScore.ToString();
        } else
        {
            _blueScore++;

            blueScoreText.text = _blueScore.ToString();
        }

        Debug.Log("GOALLLL!!!!! " + gateColor);
    }

}

public enum GateColor
{
    RED = 0, BLUE = 1
}
