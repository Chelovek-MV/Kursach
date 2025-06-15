using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    public LayerMask playerLayer; // Слой игрока

    void OnTriggerStay2D(Collider2D other)
    {
        // Проверяем, принадлежит ли объект слою игрока
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            // Если игрок попал в триггер, толкаем его обратно
            PushPlayerBack(other.transform);
        }
    }

    void PushPlayerBack(Transform player)
    {
        // Вычисляем направление от границы к игроку
        Vector2 direction = GetDirectionToCenter(player.position);

        // Толкаем игрока обратно внутрь границы
        player.position += (Vector3)direction * Time.deltaTime * 10f;
    }

    Vector2 GetDirectionToCenter(Vector2 position)
    {
        // Определяем центр карты (можно заменить на конкретные координаты)
        Vector2 center = new Vector2(0, 0);

        // Вычисляем направление от границы к центру
        return (center - position).normalized;
    }
}