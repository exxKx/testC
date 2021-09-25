using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    public Button musicOnOff;
    public Button play;
    public Text musicText;

    public static Boolean musicOn = true;

    private string sceneForPlay = "SampleScene";
    
    private void Start()
    {
        play.onClick.AddListener(PlayClick);
        musicOnOff.onClick.AddListener(MusicClick);
    }

    private void MusicClick()
    {
        musicOn = !musicOn;
        musicText.text = musicOn ? "" : "OFF";
    }

    private void PlayClick()
    {
        SceneManager.LoadScene(sceneForPlay);
        ScoreManager.StartScore();
    }

}