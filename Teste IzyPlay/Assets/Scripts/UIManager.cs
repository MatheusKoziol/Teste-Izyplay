using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public GameObject victoryUI;
    public TMP_Text victoryUIScoreText;


    // Update is called once per frame
    void Update()
    {
        if(scoreText != null) scoreText.text = "SCORE: " + ScoreManager.Instance.score.ToString();
    }


    public void EndGameUI()
    {
        scoreText.gameObject.SetActive(false);
        victoryUI.SetActive(true);
        victoryUIScoreText.text = "SCORE: " + ScoreManager.Instance.score.ToString();
    }


    public void ChangeScene(string newSceneName)
    {
        SceneManager.LoadScene(newSceneName);
        ScoreManager.Instance.score = 0;
        Time.timeScale = 1;
    }
}
