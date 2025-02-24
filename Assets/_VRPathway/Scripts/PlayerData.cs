using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    public bool isGameActive;

    public int m_playerScore;

    public int m_currentPlayerScore;

    public int m_pastPlayerScore;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        isGameActive = false;

    }
}
