using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    [SerializeField]
    private Button buttonPause;

    [SerializeField]
    private CanvasGroup gameOverPanel;

    [SerializeField]
    private Text textTimer;
    private CanvasGroup canvasMenu;
    private SaveLoadManager saveLoadManager;
    private int time;
    void Start()
    {
        canvasMenu = GetComponent<CanvasGroup>();
        saveLoadManager = new SaveLoadManager();
        AudioListener.volume = saveLoadManager.getSound();
        Time.timeScale = 1;
        if(textTimer != null)
        {
            FindObjectOfType<PlayerMovement>().canMove = false;
            StartCoroutine(PauseEndtimer());
        }
    }

    private void toggleMenu()
    {
        if(canvasMenu.alpha == 1)
        {
            canvasMenu.alpha = 0;
            canvasMenu.blocksRaycasts = false;
            canvasMenu.interactable = false;
        }
        else
        {
            canvasMenu.alpha = 1;
            canvasMenu.blocksRaycasts = true;
            canvasMenu.interactable = true;
        }
    }

    public void pauseGameButton()
    {
        Time.timeScale = 0;
        buttonPause.interactable = false;
        toggleMenu();
    }

    public void resumeGameButton()
    {
        FindObjectOfType<PlayerMovement>().canMove = false;
        Time.timeScale = 1;
        toggleMenu();
        StartCoroutine(PauseEndtimer());
    }

    public void toggleSoundButton()
    {
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        saveLoadManager.setSound(((int)AudioListener.volume));
    }

    public void quitGameButton()
    {
        Application.Quit();
    }

    public void returnToMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void restartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void showGameOverPanel()
    {
        buttonPause.interactable = false;
        gameOverPanel.alpha = 1;
        gameOverPanel.interactable = true;
        gameOverPanel.blocksRaycasts = true;
    }

    public void startGameButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    IEnumerator PauseEndtimer()
    {
        time = 3;
        while(time > 0)
        {
            textTimer.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
        textTimer.text = "";
        FindObjectOfType<PlayerMovement>().canMove = true;
        buttonPause.interactable = true;
    }
}
