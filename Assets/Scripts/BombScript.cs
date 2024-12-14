using UnityEngine;
using DG.Tweening;

public class BombScript : MonoBehaviour
{
    public float radius = 3f, delay = 3f;

    public LayerMask maskOfCircles;

    public ParticleSystem circleParticles, bombParticles;
    public AudioClip bombSound;

    private void Explode()
    {
        Collider2D[] objectsToDestroy = Physics2D.OverlapCircleAll(transform.position, radius, maskOfCircles);

        foreach (Collider2D c in objectsToDestroy) 
        { 
            GameObject destroyed = c.gameObject;
            if (destroyed.tag == "1") { ScoreScript.score += 1 * 2; }
            else if (destroyed.tag == "2") { ScoreScript.score += 2 * 2; }
            else if (destroyed.tag == "3") { ScoreScript.score += 4 * 2; }
            else if (destroyed.tag == "4") { ScoreScript.score += 8 * 2; }
            else if (destroyed.tag == "5") { ScoreScript.score += 16 * 2; }
            else if (destroyed.tag == "6") { ScoreScript.score += 32 * 2; }
            else if (destroyed.tag == "7") { ScoreScript.score += 64 * 2; }
            else if (destroyed.tag == "8") { ScoreScript.score += 128 * 2; }
            else if (destroyed.tag == "9") { ScoreScript.score += 256 * 2; }
            else if (destroyed.tag == "10") { ScoreScript.score += 512 * 2; }
            else if (destroyed.tag == "11") { ScoreScript.score += 1024 * 2; }
            else if (destroyed.tag == "12") { ScoreScript.score += 2048 * 2; }
            ParticleSystem part = Instantiate(circleParticles, destroyed.transform.position, Quaternion.identity);
            Destroy(destroyed); 
        }


        ParticleSystem bombPart = Instantiate(bombParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (ScoreScript.sound) { AudioSource.PlayClipAtPoint(bombSound, transform.position); }
    }

    private void Update()
    {
        if (transform.position.y < 3.5f) { transform.DOScale(1.4f, delay).OnComplete(() => { Explode(); }); }
    }
}