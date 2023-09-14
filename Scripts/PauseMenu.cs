using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    private GameObject CardsCanvas;
    void Start()
    {
        CardsCanvas = GameObject.Find("CardsCanvas");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        CardsCanvas.SetActive(true);
        Time.timeScale = 0.5f;
        isGamePaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        CardsCanvas.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverMenuUI.SetActive(false);
        CardsCanvas.SetActive(true);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
