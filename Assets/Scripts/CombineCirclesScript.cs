using UnityEngine;

public class CombineCirclesScript : MonoBehaviour
{
    public GameObject[] circles; // Префабы кругов для создания нового уровня
    public GameObject particles; // Эффект соединения
    public AudioClip combineSound; // Звук соединения
    public int scoreValue; // Очки за соединение
    private float timer, timeToLose = 1.5f;

    private bool isMerging = false; // Флаг, чтобы предотвратить повторное соединение

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, совпадают ли теги объектов
        if (collision.gameObject.CompareTag(gameObject.tag) && !isMerging)
        {
            // Проверяем, какой из объектов должен обработать соединение (по уникальному ID)
            int myInstanceID = GetInstanceID();
            int otherInstanceID = collision.gameObject.GetInstanceID();

            if (myInstanceID > otherInstanceID)
            {
                // Другой объект обработает соединение
                return;
            }

            // Флаг для предотвращения повторной обработки
            isMerging = true;

            // Получаем уровень текущего круга
            int currentLevel = int.Parse(gameObject.tag);

            // Проверяем, существует ли следующий уровень
            if (currentLevel < circles.Length)
            {
                // Создаём новый круг на месте соединения
                GameObject newCircle = Instantiate(
                    circles[currentLevel], // Следующий уровень круга
                    transform.position, // Текущая позиция
                    Quaternion.identity // Без вращения
                );

                // Добавляем эффект соединения
                if (particles != null)
                {
                    Instantiate(particles, transform.position, Quaternion.identity);
                }

                // Проигрываем звук
                if (combineSound != null)
                {
                    AudioSource.PlayClipAtPoint(combineSound, transform.position);
                }

                // Увеличиваем счёт
                ScoreScript.score += scoreValue;

                // Уничтожаем текущие круги
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
