using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnTransform;  // Check Point, Save Point ���� ��ġ �������ִ� ���

    private PlayerController playerContorller;          // PlayerContorller���� ���� ������Ʈ ���� �߰������ �մϴ�.
    private PlayerCam playercam;                        // playercam Ŭ�������� ����. RespawnPlayer���� Playercam ������ �� �ְ� �ڵ带 �ۼ��غ�����.
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

        playerContorller = player.GetComponent<PlayerController>(); // �ٸ� �ڵ忡 ���� �ϴ� ���
        playerCam.playerTransform = player.transform;
        playerCam.SetOffset();
    }
}
