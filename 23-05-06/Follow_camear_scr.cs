using UnityEngine;

public class Follow_camear_scr : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float minPosX = -0.12f;
    public float maxPosX = 13.11f;

    private void LateUpdate()
    {
        // ī�޶� ��ġ�� ���ΰ� ��ġ + offset���� ����
        Vector3 targetPos = target.position + offset;

        // ����Ʈ ���� ����Ͽ� ī�޶� ��ġ�� ����
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(targetPos);
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0, 1);
        viewportPos.y = Mathf.Clamp(viewportPos.y, 0, 1);
        Vector3 clampedPos = Camera.main.ViewportToWorldPoint(viewportPos);

        // x ��ǥ�� ����
        clampedPos.x = Mathf.Clamp(clampedPos.x, minPosX, maxPosX);

        transform.position = clampedPos;
    }
}