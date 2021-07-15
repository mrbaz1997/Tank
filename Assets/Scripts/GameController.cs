using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int m_PlayerNumber;
    //public bool deadCheck=false;
    public GameObject RestartButton;
    private static int m_wins1=0;
    private static int m_wins2=0;

    public TextMeshProUGUI m_finishText;
    public TextMeshProUGUI m_winsText1;
    public TextMeshProUGUI m_winsText2;

    private void Start()
    {
        m_winsText1.text = "Player1: " + m_wins1;
        m_winsText2.text = "Player2: " + m_wins2;
    }
    public void GameOver()
    {
        if (m_PlayerNumber == 1)
        {
            m_wins2++;
            m_winsText2.text = "Player2: " + m_wins2;
            m_finishText.text = "Player 2 win!";
        }
        else if (m_PlayerNumber == 2)
        {
            m_wins1++;
            m_winsText1.text = "Player1: " + m_wins1;
            m_finishText.text = "Player 1 win!";
        }

        RestartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
