using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Player player;
    [SerializeField] private Animator loadingScreenAnim;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject endScreenPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        endScreenPanel.SetActive(false);
        instance = this;
        player = FindObjectOfType<Player>();  
    }

    public void LoadingGame(int index)
    {
        StartCoroutine(GetSceneLoadProgress(index));
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void EndScreenPanel()
    {
        endScreenPanel.SetActive(true);
        Time.timeScale = 0;

    }
    public void PausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public IEnumerator GetSceneLoadProgress(int index)
    {
        loadingScreenAnim.SetTrigger("Load");
        yield return new WaitForSecondsRealtime(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        loadingScreenAnim.SetTrigger("Deload");
        // loadingScreen.gameObject.SetActive(false);
    }

}
