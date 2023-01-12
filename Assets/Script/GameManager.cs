using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float timeforwait = 3.0f;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool gameActive;
    public Button RestartButton;
    public GameObject titlepage;
    public TextMeshProUGUI livesText;
    public int lives = 3;
    public bool titlePageActive = true;
    public bool ispaused;
    public TextMeshProUGUI pausedText;
    

    private void Update()
    {
        if (gameActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ispaused = !ispaused;
                if (ispaused)
                {
                    Time.timeScale = 0;
                    pausedText.gameObject.SetActive(true);

                }
                else
                {
                    Time.timeScale = 1;
                    pausedText.gameObject.SetActive(false);
                }
            }
        }
       
    }

    IEnumerator spawnTargets()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(timeforwait);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void updateScore(int index)
    {
        score += index;
        scoreText.text = "Score : "+ score;
    }
    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        gameActive = false;
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game");
    }
    public void startGame(int difficulty)
    {
        gameActive = true;
        titlepage.gameObject.SetActive(false);
        titlePageActive = false;
        timeforwait = timeforwait / difficulty;
        StartCoroutine(spawnTargets());
        updateScore(0);
        livesText.text = "Lives :" + lives;
    }
    public void livesFunction()
    {
        lives--;
        livesText.text = "Lives :" + lives;
    } 
}
