using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ScoreScript : MonoBehaviour
{
    static public bool isPause, sound;
    static public int score, bestScore;

    public Text scoreText, gameOverText, startText, restartText;
    public GameObject pause;
    public Sprite soundOn, soundOff;
    public Button soundButton;

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    private void Start()
    {
        sound = true;
        isPause = false;
        score = 0;
        bestScore = PlayerPrefs.GetInt("BestScore");
        pause.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        YandexGame.FullscreenShow();
    }

    public void PauseMenuOpen()
    {
        pause.SetActive(true);
        isPause = true;
    }

    public void PauseMenuClose()
    {
        pause.SetActive(false);
        isPause = false;
    }

    public void Sound()
    { 
        Image image = soundButton.GetComponent<Image>();
        if (sound == true)
        {
            sound = false;
            image.sprite = soundOff;
        }
        else
        {
            sound = true;
            image.sprite = soundOn;
        }
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        if (score > bestScore)
        {
            bestScore = score;
            SetToLeaderboard(score);
        }
        if (Language.instance.currentLanguage == "ru") { gameOverText.text = "Твой лучший счет: " + bestScore.ToString(); }
        else { gameOverText.text = "Your best score: " + bestScore.ToString(); }
        PlayerPrefs.SetInt("BestScore", bestScore);
    }
}
