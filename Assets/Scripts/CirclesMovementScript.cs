using UnityEngine;
using DG.Tweening;

public class CirclesMovementScript : MonoBehaviour
{
    static public bool isFollowing = true;

    public GameObject trail;

    private Rigidbody2D rb;
    private TrailRenderer trailRenderer;

    private Vector2 mousePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        TrailRenderer trailRenderer = trail.GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;

        if (gameObject.transform.position.y >= 3.5f) 
        {
            transform.localScale = Vector3.zero;
            if (gameObject.name == "1(Clone)") { transform.DOScale(0.8f, 0.5f); }
            else if (gameObject.name == "2(Clone)" || gameObject.name == "Bomb(Clone)") { transform.DOScale(1f, 0.5f); }
            else if (gameObject.name == "3(Clone)") { transform.DOScale(1.2f, 0.5f); }
        }
    }

    public void DestroyScript()
    {
        Destroy(GetComponent<CirclesMovementScript>());
    }

    private void Update()
    {
        if (!ScoreScript.isPause)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (Input.GetMouseButtonDown(0) && mousePosition.x >= -3f && mousePosition.x <= 3f)
            {
                rb.gravityScale = 1;
                TrailRenderer trailRenderer = trail.GetComponent<TrailRenderer>();
                trailRenderer.enabled = true;
            }
            if (isFollowing)
            {
                if (mousePosition.x < -2.8f || mousePosition.x > 2.8f || gameObject.transform.position.y < 3.5f)
                {
                    isFollowing = false;
                }
                else
                {
                    transform.position = new Vector2(mousePosition.x, transform.position.y);
                }
            }
            else
            {
                if (mousePosition.x >= -2.23f && mousePosition.x <= 2.2f)
                {
                    isFollowing = true;
                }
            }
            if (gameObject.transform.position.y < 3.5f)
            {
                rb.gravityScale = 1;
                DestroyScript();
            }
        }
    }
}


