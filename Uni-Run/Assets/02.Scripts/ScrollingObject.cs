using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;   // �̵� �ӵ�

    private void Update()   // ���� ������Ʈ�� ���� �ӵ��� �������� �����̵��ϴ� ó��
    {
        transform.Translate((transform.right * -1) * speed * Time.deltaTime);   // �ʴ� speed�� �ӵ��� �������� �����̵�
    }
}
