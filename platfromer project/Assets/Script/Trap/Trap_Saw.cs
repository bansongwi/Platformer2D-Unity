
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Trap_Saw : MonoBehaviour
{
    public Animator anim;
    public Transform[] movePositions;         // 톱니바퀴가 이동할 위치를 지정할 변수
    public float speed = 5f;
    public int moveIndex = 0;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
        isWorking = true();
    }
    private void Update()  // 컴퓨터 성능 영향을 받는다.
    {
        anim.SetBool("isWorking", isWorking);  
    
        MoveTrap();
    }

    private void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed / Time.deltaTime);

        // 조건문 - 함정이 목표한 지점까지 도착했는지?
       if (Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            moveIndex++;
        }
        // 다음 목표 지점이 없으면.. moveIndex = 0
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
