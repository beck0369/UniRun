using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour // ���� ������ ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
{
    private float width;    // ����� ���� ����

    private void Awake()    // ���� ���̸� �����ϴ� ó��
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();   // BoxCollider2D ������Ʈ�� Size �ʵ��� x ���� ���� ���̷� ���
        width = backGroundCollider.size.x;
    }

    private void Update()   // ���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
    {
        if (transform.position.x <= -width)
        {
            RePosition();   // ���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
        }
    }

    private void RePosition()   // ��ġ�� ���ġ�ϴ� �޼���
    {
        // ���� ��ġ���� ���������� ���� ���� * 2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        // transform.position = transform.position + new Vector3(width * 2, 0f, 0f);
    }
}
