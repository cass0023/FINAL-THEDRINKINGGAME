using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int lives = 5;
    public TextMeshProUGUI playerLives;
    public void lossLife()
    {
        lives--;

        if (lives == 0)
        {
            Debug.Log("No more lives");
        }
    }
    public void Update()
    {
        playerLives.text = lives.ToString();
    }
}
