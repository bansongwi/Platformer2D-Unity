using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // ������ �������� ����

    Vector3 offset;                             // ī�޶�� �÷��̾��� ��ġ ����
    public Transform playerTransform;           // �÷��̾��� ���� ��ġ (�÷��̾ ������ �� ����ǰ�, ī�޶� �ش� ��ġ�� ���̸�ŭ �Ѿư�
    public float fixedYPosition;
    [Range(0f, 1f)]
    public float smoothValue;

    // Start is called before the first frame update
    void Start()
    {

        // transform = ī�޶�, ������ ��, ���� -> A - B : B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - playerTransform.position;

        fixedYPosition = transform.position.y;
    }


    public void SetOffset()
    {
        offset = transform.position - playerTransform.position;
    }

    // Lerp, Linear Interpolation ���� ����
    // �� ������ �� ��, �� �� ������ ������ ��ġ�� ���� �ľ��ϱ� ���� ������ ����
    // �� ��(point) -(Vector3). ī�޶��� ���� ��ġ. �̵� �ϰ� ���� ��ġ, ī�޶� -> (point)-> ��ǥ


    // U�÷��̾��� ������ Update ����� �Ŀ� ī�޶� �i�Ƽ� �����̱� ���ؼ�.
    // Vector3.Lerp�Լ� ������ �Ǿ� �ֽ��ϴ�.
    void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;  // ������ �� �������� ī�޶��� ��ġ�� ���Ѵ�.
        targetPosition.y = fixedYPosition;                           // ī�޶��� Y(����)�� ������Ų��.
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);

        transform.position = smoothPosition;      // ������ �÷��̾��� x�������θ� ����ٴϰ�, Y�� ������Ų ������ ī�޶� �̵���Ų��.
    }
}
