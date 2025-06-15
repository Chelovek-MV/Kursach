using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    public LayerMask playerLayer; // ���� ������

    void OnTriggerStay2D(Collider2D other)
    {
        // ���������, ����������� �� ������ ���� ������
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            // ���� ����� ����� � �������, ������� ��� �������
            PushPlayerBack(other.transform);
        }
    }

    void PushPlayerBack(Transform player)
    {
        // ��������� ����������� �� ������� � ������
        Vector2 direction = GetDirectionToCenter(player.position);

        // ������� ������ ������� ������ �������
        player.position += (Vector3)direction * Time.deltaTime * 10f;
    }

    Vector2 GetDirectionToCenter(Vector2 position)
    {
        // ���������� ����� ����� (����� �������� �� ���������� ����������)
        Vector2 center = new Vector2(0, 0);

        // ��������� ����������� �� ������� � ������
        return (center - position).normalized;
    }
}