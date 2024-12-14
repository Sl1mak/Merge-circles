using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class AdScript : MonoBehaviour
{
    private float timer, timeToAd = 80, timerToAd = 0.3f;

    static public bool isAdvPause, adCheck;

    public GameObject bomb;
    public Transform spawnBomb;

    [DllImport("__Internal")]
    private static extern void BombFromAdYan();

    private void Start()
    {
        isAdvPause = false;
        adCheck = false;
        timer = 0;
    }

    public void ResumeAfterAd() { isAdvPause = false; }
    
    public void StopBeforeAd() { isAdvPause = true; }

    public void BombFromAd()
    {
        GameObject newBomb = Instantiate(bomb, spawnBomb.position, Quaternion.identity);
    }

    public void RewardAd()
    {
        BombFromAdYan();
    }

    public void Ad()
    {
        if (SpawnerScript.isSpawned)
        {
            isAdvPause = true;
            if (timerToAd <= 0)
            {
                YandexGame.FullscreenShow();
                timerToAd = 0.3f;
                timer = 0;
            }
            else
            {
                timerToAd -= Time.deltaTime;
            }
        }
    }

    private void Update()
    {
        if (!ScoreScript.isPause && !BorderScript.isGameOver)
        {
            if (timer >= timeToAd)
            {
                Ad();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
