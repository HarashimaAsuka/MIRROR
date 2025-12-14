using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private Text timeText;

    public float gameTime = 60;

    private float restTime;
    private bool isPlaying = true;

    public Text gameOverText;
    public Text highScoreText;
    public Button retryButton;

    private string getRestTimeText(){
        int integer = Mathf.FloorToInt(this.restTime);

        return integer.ToString("00") + ":" + Mathf.FloorToInt((this.restTime - integer) * 100).ToString("00");
    }

    void Start(){
        this.isPlaying = true;
        this.restTime = this.gameTime;
        this.timeText = this.GetComponent<Text>();
        this.timeText.text = getRestTimeText();
    }

    void Update(){
        this.restTime -= Time.deltaTime;
        if(this.restTime > 0){
            this.timeText.text = getRestTimeText();
        }

        else{
            this.timeText.text = "00:00";

            if(this.isPlaying){
                this.isPlaying = false;
                Time.timeScale = 0.0f;

                ScoreManager scoreManager = ScoreManager.Instance;

                scoreManager.compareHighScore();


                // this.highScoreText.gameObject.SetActive(true);

                // this.highScoreText.text = "High Score:" + scoreManager.getHighScore();

                this.gameOverText.gameObject.SetActive(true);

                this.retryButton.gameObject.SetActive(true);

                scoreManager.initializeCurrentScore();

                
            }

            else{
                if(Input.GetKeyDown(KeyCode.N)){
                    Time.timeScale = 1.0f;
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
