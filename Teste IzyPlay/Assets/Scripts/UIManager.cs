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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreText != null) scoreText.text = "SCORE: " + ScoreManager.Instance.score.ToString();
    }


    public void EndGameUI()
    {
        scoreText.gameObject.SetActive(false);
        victoryUI.SetActive(true);
    }


    public void ChangeScene(string newSceneName)
    {
        SceneManager.LoadScene(newSceneName);
        Time.timeScale = 1;
    }
}
