using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ѵ��ϱ� ���ؼ��� �� ��ü �� �� ��ü�� Rigidbody(2D)�� ������Ʈ�� �����ؾ��ϸ�,
// 
// �÷��̾�� �⵿�ϸ� �浹���� ������ �̺�Ʈ(�����) �۵��Ѵ�.
public class Trap : MonoBehaviour
{
    // �浹 �̺�Ʈ�� �ۼ��� ��, ��� ������Ʈ�� ������� �ۼ��� ���� ���� ����.
    // ���� ���� �鿡���� ��ȿ�����Դϴ�.
    // �浹 �̺�Ʈ�� Ư�� ��� �۵��ϵ��� �±�(����ǥ) �޾��ش�. - ���� ������Ʈ �� ���� �±� ����.
    // Tag - ������ �浹 �̺�Ʈ���� ���
    // Layer - �̺�Ʈ�� �۵� �Ҷ� Ư�� ��� �з����ִ� ����. �� ������Ʈ�� �������� ���̾ ���� �� �� �ִ�.
    // 
    // Collider 2D�̰� Rigidbody 2D �����Ѵ�. �ʼ�����

    bool isWorking = false;

   protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        /*�÷��̾� ��ũ�� ���� �ִ°�?*/
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player�� ������ �ǰ� ����.(Collisioin �浹)");
        }
       
    }

   protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        /*�÷��̾� ��ũ�� ���� �ִ°�?*/
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player�� ������ �ǰ� ����.(Trigger�浹)");
        }
    }
}
