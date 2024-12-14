using UnityEngine;

public class CombineCirclesScript : MonoBehaviour
{
    public GameObject[] circles; // ������� ������ ��� �������� ������ ������
    public GameObject particles; // ������ ����������
    public AudioClip combineSound; // ���� ����������
    public int scoreValue; // ���� �� ����������
    private float timer, timeToLose = 1.5f;

    private bool isMerging = false; // ����, ����� ������������� ��������� ����������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ��������� �� ���� ��������
        if (collision.gameObject.CompareTag(gameObject.tag) && !isMerging)
        {
            // ���������, ����� �� �������� ������ ���������� ���������� (�� ����������� ID)
            int myInstanceID = GetInstanceID();
            int otherInstanceID = collision.gameObject.GetInstanceID();

            if (myInstanceID > otherInstanceID)
            {
                // ������ ������ ���������� ����������
                return;
            }

            // ���� ��� �������������� ��������� ���������
            isMerging = true;

            // �������� ������� �������� �����
            int currentLevel = int.Parse(gameObject.tag);

            // ���������, ���������� �� ��������� �������
            if (currentLevel < circles.Length)
            {
                // ������ ����� ���� �� ����� ����������
                GameObject newCircle = Instantiate(
                    circles[currentLevel], // ��������� ������� �����
                    transform.position, // ������� �������
                    Quaternion.identity // ��� ��������
                );

                // ��������� ������ ����������
                if (particles != null)
                {
                    Instantiate(particles, transform.position, Quaternion.identity);
                }

                // ����������� ����
                if (combineSound != null)
                {
                    AudioSource.PlayClipAtPoint(combineSound, transform.position);
                }

                // ����������� ����
                ScoreScript.score += scoreValue;

                // ���������� ������� �����
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
