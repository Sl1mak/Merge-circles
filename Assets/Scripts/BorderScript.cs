using DG.Tweening;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public GameObject spawner, gameOver;

    static public bool isGameOver;

    private float timer, timeToLose = 1.5f;
    private bool isLose = false;

    private void Start()
    {
        gameOver.transform.localScale = Vector3.zero;
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLosingTag(collision.gameObject.tag))
        {
            isLose = true;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (IsLosingTag(collision.gameObject.tag))
    //    {
    //        if (timer >= timeToLose)
    //        {
    //            Destroy(spawner);
    //            gameOver.SetActive(true);
    //            gameOver.transform.DOScale(0.5625f, 1);
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsLosingTag(collision.gameObject.tag))
        {
            isLose = false;
        }
    }

    private bool IsLosingTag(string tag)
    {
        return tag == "1" || tag == "2" || tag == "3" || tag == "4" ||
               tag == "5" || tag == "6" || tag == "7" || tag == "8" ||
               tag == "9" || tag == "10" || tag == "11" || tag == "12";
    }

    private void Update()
    {
        Debug.Log(isLose);
        Debug.Log(timer);
        if (isLose) { timer += Time.deltaTime; }
        else { timer = 0; }
        if (timer >= timeToLose)
        {
            Destroy(spawner);
            gameOver.SetActive(true);
            gameOver.transform.DOScale(0.5625f, 1);
        }
    }
}