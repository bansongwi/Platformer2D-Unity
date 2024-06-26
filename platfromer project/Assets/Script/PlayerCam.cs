using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // 벡터의 연산으로 구현

    Vector3 offset;                             // 카메라와 플레이어의 위치 차이
    public Transform playerTransform;           // 플레이어의 현재 위치 (플레이어가 움직일 때 변경되고, 카메라가 해당 위치를 차이만큼 쫓아감
    public float fixedYPosition;
    [Range(0f, 1f)]
    public float smoothValue;

    // Start is called before the first frame update
    void Start()
    {

        // transform = 카메라, 벡터의 합, 빼기 -> A - B : B에서 출발해서 A까지 이동하는 화살표
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }


    public void SetOffset()
    {
        offset = transform.position - playerTransform.position;
    }

    // Lerp, Linear Interpolation 선형 보간
    // 양 끝점을 알 때, 두 점 사이의 임의의 위치를 쉽게 파악하기 위한 수학적 개념
    // 두 점(point) -(Vector3). 카메라의 현재 위치. 이동 하고 싶은 위치, 카메라 -> (point)-> 목표


    // U플레이어의 움직임 Update 실행된 후에 카메라가 쫒아서 움직이기 위해서.
    // Vector3.Lerp함수 구현이 되어 있습니다.
    void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;  // 벡터의 합 연산으로 카메라의 위치를 구한다.
        targetPosition.y = fixedYPosition;                           // 카메라의 Y(높이)는 고정시킨다.
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);

        transform.position = smoothPosition;      // 실제로 플레이어의 x방향으로만 따라다니고, Y는 고정시킨 값으로 카메라를 이동시킨다.
    }
}
