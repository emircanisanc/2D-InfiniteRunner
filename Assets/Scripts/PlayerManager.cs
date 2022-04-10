using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private bool isDead;
    [SerializeField]
    private PlayerSoundController playerSoundController;

    [SerializeField]
    private Text highScoreText;

    [SerializeField]
    private Text playerScoreText;

    private Animator animator;

    private PlayerMovement playerMovement;
    private float playerScore;
    void Start()
    {
        isDead = false;
        playerScore = 0;
        animator = GetComponent<Animator>();
        highScoreText.text = loadHighestScore().ToString();
        playerScoreText.text = ((int)playerScore).ToString();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void applyDamage()
    {
        isDead = true;
        playerMovement.canMove = false;
        animator.SetBool("isDead", isDead);
        playerSoundController.playDieSound();
        FindObjectOfType<GameSoundManager>().stopMusic();
        FindObjectOfType<MenuManagerInGame>().showGameOverPanel();
        saveHighestScore();
        Time.timeScale = 0;
    }

    private void saveHighestScore()
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();
        if(playerScore > saveLoadManager.getHighScore())
        {
            saveLoadManager.setHighestScore(((int)playerScore));
        }
    }

    void FixedUpdate()
    {
        if(playerMovement.canMove)
        {
            playerScore = playerScore + 0.5f;
            if(playerScore % 100 == 0 && playerScore < 1500)
            {
                playerMovement.runFaster();
            }
            playerScoreText.text = ((int)playerScore).ToString();
        }
    }

    private int loadHighestScore()
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();
        return saveLoadManager.getHighScore();
    }
}
