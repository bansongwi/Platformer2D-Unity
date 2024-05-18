
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Trap_Saw : MonoBehaviour
{
    public Animator anim;
    public Transform[] movePositions;         // ��Ϲ����� �̵��� ��ġ�� ������ ����
    public float speed = 5f;
    public int moveIndex = 0;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
        isWorking = true();
    }
    private void Update()  // ��ǻ�� ���� ������ �޴´�.
    {
        anim.SetBool("isWorking", isWorking);  
    
        MoveTrap();
    }

    private void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed / Time.deltaTime);

        // ���ǹ� - ������ ��ǥ�� �������� �����ߴ���?
       if (Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex++;
        }
        // ���� ��ǥ ������ ������.. moveIndex = 0
        if(movePositions.Length <= moveIndex)
        {
            moveIndex = 0;
        }
    }
    protected override OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
