using System;
using UnityEngine;

// 접근 지정자 public private
public class PlayerController : MonoBehaviour
{
    // Strart, Update 유니티 이벤트 함수의 같은 이름이 있는지 조사
    // 같은 이름이 있으면? 유니티에서 정해놓은 실행 시간에 그 함수를 실행

    // Start is called before the first frame update
    // 첫 프레임이 불러지기전에 (한번) 시작한다. 한번만!

    // 속도, 방향
    [Header("이동")]
    public float moveSpeed = 5f;  // 캐릭터의 이동 속도
    private float moveInput; // 플레이어의 방향 및 인풋 데이터 저장

    public Transform startTransform; // 캐릭터가 시작할 위치를 저장하는 변수
    public float JumpForce = 10f;
    public Rigidbody2D rigidbody2D; //물리(강체) 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded;  // true : 캐릭터가 점프 할 수 있는 상태, false : 점프 못함
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    [Header("Filp")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;

    public Animator animator;
    private bool isMove;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log("Hello Unity");
        // 현재 내 위치 <= 새로운 x,y 저장하는 데이터 타입( 현재 x좌표, 10 y좌표)
        //transform.position = new Vector2(transform.position.x, 10);

        // 현재 내 위치를 startTransform으로 변경
        InitializePlayerStatus();
    }

    void InitializePlayerStatus()
    {
       // transform.position = startTransform.position;
        rigidbody2D.velocity = Vector2.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
    }

    // Update is called once per frame
    // 1 프레임에 한번 호출된다. - 반복적으로 실행
    void Update()
    {
        // 함수 이름 앞에 마우스커서를 두고 Ctlr + r + r
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Move();
        FallDownCheck();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // 점프 : Y Position _ rigidbody Y velocity를 점프 파워만큼 올려주면된다.
            Jump();
        }       
    }

    private void FallDownCheck()
    {
        // y의 높이가 특정 지점보다 낮을때 낙사한 것으로 간주한다. => 충돌 체크 대체
        if (transform.position.y < -11)
        {
            InitializePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : 현재 rigidbody 속도 = 0 움직이지 않는 상태, !=0 움직이고 있는 상태
        isMove = rigidbody2D.velocity.x != 0;
        animator.SetBool("isMove", isMove);
        animator.SetBool("isGrounded", isGrounded);
        // SetFloat 함수에 의해서 y최대일 때 1로 변한.. y 최소일 때 -1로 변환
        // 점프 키를 누르면. 순간적으로 y 높이 증가, 중력에 의해서 점점 y 속도 -까지 내려감.
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);
    }

    /// <summary>
    /// 점프를 할 때 땅인지 아닌지 체크 하는지 기능 -> Collider Check
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }
    /// <summary>
    /// 플레이어 입력 값을 받아와야 합니다. a,d 키보드 좌 우 키를 눌렀을때 -1 ~ 1 반환하는 클래스
    /// </summary>
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();
    }

    private void HandleFlip()
    {
        // 오른쪽 방향을 바라보고 있을 때
        if(facingRight && moveInput < 0 )
        {
            Flip();
        }
        // 왼쪽 방향으로 바라보고 있을 때
        else if (!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }
    private void Move()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);
    }
    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }
    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }
}
