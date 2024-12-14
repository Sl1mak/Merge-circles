using DG.Tweening;
using UnityEngine;

public class ZondryScript : MonoBehaviour
{
    public float timeToAnim;

    private float timer, positionMove;
    private bool isAnim;

    private Vector3 startPosition, vectorRotation, startVectorRotation;

    private void Start()
    {
        if (transform.position.x > 0) { positionMove = -0.40f; vectorRotation = new Vector3(0, 0, 20); } else { positionMove = 0.40f; vectorRotation = new Vector3(0, 180, 20); }
        startPosition = transform.localPosition;
    }

    public void Anim()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(transform.position.x + positionMove, 2));
        sequence.Join(transform.DORotate(vectorRotation, 2));
        sequence.AppendInterval(2);
        sequence.Append(transform.DOMoveX(transform.position.x, 2));
        sequence.Join(transform.DORotate(new Vector3(0, transform.rotation.y, 0), 2));
        sequence.Play();
        sequence.OnComplete(() => { isAnim = false; });
    }

    private void Update()
    {
        if (!isAnim) { timer += Time.deltaTime; }
        if (timer >= timeToAnim) { Anim(); timer = 0; isAnim = true; }
    }
}
