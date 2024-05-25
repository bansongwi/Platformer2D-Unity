using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;  // Check Point, Save Point 시작 위치 변경해주는 기능

    private PlayerController playerContorller;          // PlayerContorller에서 빠진 컴포넌트 들을 추가해줘야 합니다.
    private PlayerCam playercam;                        // playercam 클래스에서 접근. RespawnPlayer에서 Playercam 접근할 수 있게 코드를 작성해보세요.
    [SerializeField] private PlayerCam playerCam;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }
       // if (player != null)
        {
            //RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);

        playerContorller = player.GetComponent<PlayerController>(); // 다른 코드에 접근 하는 방법
        playerCam.playerTransform = player.transform;
        playerCam.SetOffset();
    }
}
