using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayingAndTImer : MonoBehaviour
{
    private float timer;

    [SerializeField] private AudioSource m_AudioSource;

    [SerializeField] private AudioClip m_AudioClip;

    [SerializeField] private float goodScore;

    [SerializeField ]private float timerStop = 60.0f;

    [SerializeField] private GameObject gameEndedScreen;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI evaluationText;

    [SerializeField] private TextMeshProUGUI currentScoreText;

    [SerializeField] private TextMeshProUGUI pastScoreText;

    void Update()
    {
        if (PlayerData.instance.isGameActive)
        {
            timer += Time.deltaTime;
            if (timer > timerStop)
            {
                gameEndedScreen.SetActive(true);
                SoundPlay(m_AudioClip);
                scoreText.text = $"Score: {PlayerData.instance.m_playerScore}";
                if (PlayerData.instance.m_currentPlayerScore == null)
                {
                    PlayerData.instance.m_currentPlayerScore = PlayerData.instance.m_playerScore;
                    currentScoreText.text = $"Current Score: {PlayerData.instance.m_currentPlayerScore}";
                    pastScoreText.text = $"Past Score: None";
                }   
                else if (PlayerData.instance.m_currentPlayerScore != null)
                { 
                    PlayerData.instance.m_pastPlayerScore = PlayerData.instance.m_currentPlayerScore;
                    PlayerData.instance.m_currentPlayerScore = PlayerData.instance.m_playerScore;
                    currentScoreText.text = $"Current Score: {PlayerData.instance.m_currentPlayerScore}";
                    pastScoreText.text = $"Past Score: {PlayerData.instance.m_pastPlayerScore}";
                }
                if (PlayerData.instance.m_playerScore > goodScore)
                {
                    evaluationText.text = "You have done an incredible job!";
                }
                else
                { 
                   evaluationText.text = "You have done an acceptable job.";
                }
                SetGameActive(false);
                timer = 0.0f;
            }
        }
    }
    
    public void SetGameActive(bool isActive)
    {
        PlayerData.instance.isGameActive = isActive;
    }

    public void ResetScore()
    {
        PlayerData.instance.m_playerScore = 0;
    }

    public void UpdatePlayerScore(int scoreUpdate)
    {
        PlayerData.instance.m_playerScore += scoreUpdate;
    }

    void SoundPlay(AudioClip audioClip)
    {
        m_AudioSource.PlayOneShot(audioClip);
    }
}
