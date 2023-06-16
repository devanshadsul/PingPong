using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    //public GameObject Ball;

    private int player1Score = 0;
    private int player2Score = 0;

    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    public TextMeshProUGUI RedWins;
    public TextMeshProUGUI BlueWins;

    public void player1Scores()
    {
        player1Score++;
        Reset();
        player1Text.text = player1Score.ToString();

    }

    public void player2Scores()
    {
        player2Score++;
        Reset();
        player2Text.text = player2Score.ToString();
    }

    public void Reset()
    {
        if(player1Score == 3)
        {
            player1Score = 0;
            player1Text.text = player1Score.ToString();
            player2Score = 0;
            player2Text.text = player2Score.ToString();
            RedWins.gameObject.SetActive(true);
            StartCoroutine(disableSet(2f));
            
        }
        if(player2Score == 3)
        {
            player1Score = 0;
            player1Text.text = player1Score.ToString();
            player2Score = 0;
            player2Text.text = player2Score.ToString();
            BlueWins.gameObject.SetActive(true);
            StartCoroutine(disableSet(2f));
        }
    }

    private IEnumerator disableSet(float disable)
    {
        yield return new WaitForSeconds(disable);

        RedWins.gameObject.SetActive(false);
        BlueWins.gameObject.SetActive(false);

    }

   
}
