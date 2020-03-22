using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoccerGameController : MonoBehaviour
{
    public Text redScoreText;
    public Text blueScoreText;
    public GameObject goalCanvas;
    AudioSource _audioSource;

    int _redScore = 0;
    int _blueScore = 0;

    float _showGoalCanvas = -1;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(CheckGoal());
    }

    IEnumerator CheckGoal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (_showGoalCanvas < Time.time && goalCanvas.activeSelf)
            {
                goalCanvas.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoal(GateColor gateColor)
    {
        PlayGoalMusic();

        goalCanvas.SetActive(true);
        _showGoalCanvas = Time.time + 5;

        SetScore(gateColor);

        Debug.Log("GOALLLL!!!!! " + gateColor);
    }

    void SetScore(GateColor gateColor)
    {
        if (gateColor == GateColor.RED)
        {
            _blueScore++;

            blueScoreText.text = _blueScore.ToString();
        }
        else
        {
            _redScore++;

            redScoreText.text = _redScore.ToString();
        }
    }

    void PlayGoalMusic()
    {
        PlaySoundInterval(_audioSource, 1, 6);
    }

    void PlaySoundInterval(AudioSource audioSource, float fromSeconds, float toSeconds)
    {
        audioSource.time = fromSeconds;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
    }

}

public enum GateColor
{
    RED = 0, BLUE = 1
}
