using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private int score;
    public Text scoreText;

    public int player = 4;
    public Text playerHP;

    public int planet = 4;
    public Text planetHP;

    public Text GameOver;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        playerHP.text = "Player HP: " + player;
        planetHP.text = "Planet HP: " + planet;
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        GameOver.gameObject.SetActive(true);
    }
    public void updateScore()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }

    public void updatePlayerHP()
    {
        player -= 1;
        playerHP.text = "Player HP: " + player;
    }

    public void updatePlanetHP()
    {
        planet -= 1;
        planetHP.text = "Planet HP: " + planet;
    }

    /*
    public void Reset()
    {
        score = 0;
        planet = 4;
        player = 4;

        scoreText.text = "Score: " + score;
        playerHP.text = "Player HP: " + player;
        planetHP.text = "Planet HP: " + planet;
    }
    */
}
