using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;   // 이동 속도

    private void Update()   // 게임 오브젝트를 일정 속도로 왼쪽으로 평행이동하는 처리
    {
        if (!GameManager.instance.isGameover)   // 게임오버가 아니라면
        {
            transform.Translate((transform.right * -1) * speed * Time.deltaTime);   // 초당 speed의 속도로 왼쪽으로 평행이동
        }
        // if (GameManager.instance.isGameover)
        // {
        //     return;
        // } 로도 사용 가능
    }
}
