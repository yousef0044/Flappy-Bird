using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{  
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    int score;

    void Awake()
    {
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i=0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Game_Over()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

   public void Increase_Score()
   {
        score ++;
        scoreText.text = score.ToString();
   }
}
