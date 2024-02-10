using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScene : MonoBehaviour
{
    public TMP_Text welcomeText;
    public TMP_Text tmScore;
    public TMP_Text tmHighScore;
    public TMP_Text tmTimeLeft;
    public TMP_Text tmName;

    public Camera[] cams;
    int camNum = 0;

    private int MAX_TIME = 45;
    private int SCORE_INCREMENT = 10;
    private int currentTime;
    private int currentScore;
    private int highScore;

    public void GoHome() {
        SceneManager.LoadScene("HomeScene");
    }

    void SetCam()
    {
        camNum++;
        if(camNum >= cams.Length)
        {
            camNum = 0;
        }
        foreach(Camera c in cams)
        {
            c.enabled = false;
        }
        cams[camNum].enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera c in cams)
        {
            c.enabled = false;
        }
        cams[camNum].enabled = true;

        if (PlayerPrefs.HasKey("username"))
        {
            welcomeText.text = "Welcome " + PlayerPrefs.GetString("username");
        }

        currentTime = MAX_TIME;

        if(PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        } else
        {
            highScore = 0;
        }

        tmHighScore.text = "High Score: " + highScore;

        StartCoroutine("LoseTime");
    }

    private void UpdateLabel()
    {
        tmScore.text = "Score: " + currentScore;
        tmTimeLeft.text = "Time Left: " + currentTime;
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;

            currentScore++;

            if (currentScore >= MAX_TIME)
                break;
        }

        GameOver();
    }

    private void GameOver()
    {
        if(highScore <= currentScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
        }
    }

    public void EndGame()
    {
        StopCoroutine("LoseTime");
        GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabel();
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("hi");
            SetCam();
        }
    }
}
