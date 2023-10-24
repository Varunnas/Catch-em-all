using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public float spawnRate;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public int score = 0;
    public bool isGameActive;
    public GameObject titleScreen;
    public TextMeshProUGUI lives;
    public int livesLeft = 3;
    public GameObject mainCamera;
    public GameObject pauseMenu;
    private bool gamePaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseGame();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomElement = Random.Range(0, targets.Count);
            Instantiate(targets[randomElement]);
        }
    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE : " + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        isGameActive=false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float spawnRates)
    {
        spawnRate = spawnRates;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        updateScore(0);
    }

    void PauseGame()
    {
        if (!gamePaused)
        {
            gamePaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gamePaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
