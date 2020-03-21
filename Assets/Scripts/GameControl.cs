using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameControl : MonoBehaviour {

    public static GameControl instance;

    public GameObject gameOverText;
    public GameObject gamePanel;
    public GameObject backgroundSound;
    public GameObject scoreSound;
    public GameObject birdDieSound;
    public GameObject button;

    public Sprite play;
    public Sprite pause;

    public DataController dataController;

    public Text scoreText;
    public Text highScore;

    public int dieCount = 0;
    private int score = 0;

    public bool gameOver=false;
    public bool gamePause = false;
    bool testMode = false;

    public float scrollSpeed;

    string gameId = "3490582";

    // Use this for initialization
    void Awake () {

        
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }

        

	}

    private void Start()
    {
        backgroundSound.GetComponent<AudioSource>().Play();
        dataController = FindObjectOfType<DataController>();
        Advertisement.Initialize(gameId, testMode);
    }

  
    // Update is called once per frame
    void Update () {


        if (gameOver==true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        scoreSound.GetComponent<AudioSource>().Play();
        score++;
    
        scoreText.text = score.ToString();
    }

    public void BirdDied()
    {
        
        birdDieSound.GetComponent<AudioSource>().Play();
        gameOver = true;
        dataController.SubmitNewPlayerScore(score);
        highScore.text = "High Score: " + dataController.GetHighestPlayerScore().ToString();
        gamePanel.SetActive(true);
        gameOverText.SetActive(true);
        backgroundSound.GetComponent<AudioSource>().Stop();

        if(score>1)
            Advertisement.Show();
    }

    public void PauseGame()
    {
        Debug.Log("Game Pause active");
        if (gamePause == false)
        {
            button.GetComponent<Image>().sprite = play;
            Time.timeScale = 0;
            gamePause = true;

        }
        else
        {
            button.GetComponent<Image>().sprite = pause;
            Time.timeScale = 1;
            gamePause = false;
        }
        //Disable scripts that still work while timescale is set to 0
    }


}
