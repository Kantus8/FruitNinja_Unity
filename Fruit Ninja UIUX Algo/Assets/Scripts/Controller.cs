using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Controller : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    private int score;
    private float spawnRate = 1f;
    public bool isGameActive;
    public GameObject titleScreen;
    public int difficulty;
    public AudioSource musique;
    public AudioSource gameOverAudio;

    public float GameSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            Debug.Log("the random index is : " + targets[index].name);
            Debug.Log("the random index is : " + index);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Social credit : " + score;
    }

    public void GameOver()
    {
        
        musique.Pause();
        
        if(isGameActive)
        {
            gameOverAudio.Play();
        }
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        InvokeRepeating("ChangeSpeed", 15,15);
        isGameActive = true;
        spawnRate = spawnRate / difficulty + 0.5f;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
    }

    private void ChangeSpeed()
    {
        Time.timeScale += GameSpeed;
    }
}
