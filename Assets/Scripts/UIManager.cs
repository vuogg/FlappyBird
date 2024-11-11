using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject menu, gameplay, finish;

    public Text scoreUI, highScoreUI, bestScoreUI;

    private void Awake()
    {
        instance = this;
        OpenMenu();
    }
    
    public void OpenMenu()
    {
        CloseAll();
        menu.SetActive(true);
    }

    public void OpenGamePlay()
    {
        CloseAll();
        gameplay.SetActive(true);

        GameManager.instance.isGamePlay = true;
        GameManager.instance.flappyBirdControl.OnInit();

        scoreUI.text = "0";
    }

    public void OpenFinish()
    {
        CloseAll();
        finish.SetActive(true);

        highScoreUI.text = GameManager.instance.flappyBirdControl.score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if(bestScore < GameManager.instance.flappyBirdControl.score)
        {
            bestScore = GameManager.instance.flappyBirdControl.score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        bestScoreUI.text = bestScore.ToString();
    }

    private void CloseAll()
    {
        menu.SetActive(false);
        gameplay.SetActive(false);
        finish.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void FinishGame()
    {
        Invoke(nameof(OpenFinish), 1.5f);
    }
}
