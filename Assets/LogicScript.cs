using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public int turnScore;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text turnScoreText;
    public bool isPlayer1Turn = true;
    public GameObject player1WinsText;
    public GameObject player2WinsText;
    public GameObject playAgainButton;
    public GameObject rollDiceButton;
    public GameObject holdButton;
    public GameObject p1TurnIndicator;
    public GameObject p2TurnIndicator;
    public Button holdBtn;
    public AudioSource victorySoundSource;

    void Start()
    {
        victorySoundSource.Stop();
    }

    void Update()
    {
        if (player1Score >= 100)
        {
            rollDiceButton.SetActive(false);
            holdButton.SetActive(false);
            player1WinsText.SetActive(true);
            playAgainButton.SetActive(true);
        }

        if (player2Score >= 100)
        {
            rollDiceButton.SetActive(false);
            holdButton.SetActive(false);
            player2WinsText.SetActive(true);
            playAgainButton.SetActive(true);
        }
    }

    public void addScore(int number)
    {
        holdBtn.interactable = true;
        if (number == 1)
        {
            turnScore = 0;
            changeTurn();
        }
        else
        {
            turnScore += number;
        }
        turnScoreText.text = turnScore.ToString();
    }

    public void changeTurn()
    {
        holdBtn.interactable = false;
        if (isPlayer1Turn)
        {
            player1Score += turnScore;
            player1ScoreText.text = player1Score.ToString();
            if (player1Score < 100)
            {
                p1TurnIndicator.SetActive(false);
                p2TurnIndicator.SetActive(true);
            }
            else
            {
                victorySoundSource.Play();
            }
        }
        else
        {
            player2Score += turnScore;
            player2ScoreText.text = player2Score.ToString();
            if (player2Score < 100)
            {
                p2TurnIndicator.SetActive(false);
                p1TurnIndicator.SetActive(true);
            }
            else
            {
                victorySoundSource.Play();
            }
        }
        turnScore = 0;
        turnScoreText.text = turnScore.ToString();
        isPlayer1Turn = !isPlayer1Turn;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
