using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeScene : MonoBehaviour
{
    public TMP_Text welcomeText;
    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToSetting()
    {
        SceneManager.LoadScene("SettingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("username")) {
            welcomeText.text = "Welcome " + PlayerPrefs.GetString("username");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
