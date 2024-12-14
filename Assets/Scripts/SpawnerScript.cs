using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] objects;
    public Text startText, circlesToBombText;

    private Vector2 mousePosition;

    static public bool isSpawned, isMouseDown;
    static public int countOfCircle;

    private int indexOfCircle, circlesToBombs;
    private float timer, timeToSpawn = 0.7f;

    private void Start()
    {
        isSpawned = false;
        timer = 0;
        countOfCircle = 0;
        circlesToBombs = 80;
    }

    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (!ScoreScript.isPause && !AdScript.isAdvPause)
        {
            if (Input.GetMouseButtonDown(0) && !isSpawned && mousePosition.x >= -3f && mousePosition.x <= 3f)
            {
                circlesToBombs--;
                countOfCircle++;
                Destroy(startText);
                mousePosition = Input.mousePosition;
                float mousePositionX = mousePosition.x;
                isSpawned = true;
                indexOfCircle = Random.Range(0, 6);
                timer = timeToSpawn;
            }
            if (isSpawned)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    mousePosition = Input.mousePosition;
                    float mousePositionX = mousePosition.x;
                    if (countOfCircle % 80 == 0) { GameObject bomb = Instantiate(objects[7], new Vector2(mousePositionX, 3.5f), Quaternion.identity); circlesToBombs = 80; }
                    else { GameObject circle = Instantiate(objects[indexOfCircle], new Vector2(mousePositionX, 3.5f), Quaternion.identity); }
                    isSpawned = false;
                }
            }
        }
        circlesToBombText.text = circlesToBombs.ToString();
    }
}

