using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingScene : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void GoHome()
    {
        PlayerPrefs.SetString("username", usernameInput.text);
        SceneManager.LoadScene("HomeScene");
    }

    public void resetHS()
    {
        PlayerPrefs.SetInt("highScore", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("username"))
        {
            usernameInput.text = PlayerPrefs.GetString("username");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
