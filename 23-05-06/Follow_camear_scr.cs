using UnityEngine;

public class Follow_camear_scr : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float minPosX = -0.12f;
    public float maxPosX = 13.11f;

    private void LateUpdate()
    {
        // 카메라 위치를 주인공 위치 + offset으로 설정
        Vector3 targetPos = target.position + offset;

        // 뷰포트 값을 사용하여 카메라 위치를 제한
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(targetPos);
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0, 1);
        viewportPos.y = Mathf.Clamp(viewportPos.y, 0, 1);
        Vector3 clampedPos = Camera.main.ViewportToWorldPoint(viewportPos);

        // x 좌표를 제한
        clampedPos.x = Mathf.Clamp(clampedPos.x, minPosX, maxPosX);

        transform.position = clampedPos;
    }
}