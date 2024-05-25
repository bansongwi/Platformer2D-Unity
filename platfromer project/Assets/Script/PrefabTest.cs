using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // 생성할 프리팹, 생성할 위치 (vector), 오브젝트의 Rotation
        // Instantiate(prefab); // prefab의 위치는 기본 위치, 회전 값으로 생성된다.
        Instantiate(prefab, spawnPosition.position, Quaternion.identity); // Quaternion.identity => Prefab이 가지고있는 각도로 생성하라.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnPrefab();
        }
    }
    private void SpawnPrefab()
    {
        Instantiate(prefab, spawnPosition.position, Quaternion.identity);
    }
}
