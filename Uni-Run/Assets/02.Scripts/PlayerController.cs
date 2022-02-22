using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour   // PlayerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
{
    public AudioClip deathClip; // ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f;  // ���� ��

    private int jumpCount = 0;  // ���� ���� Ƚ��
    private bool isGrounded = false;    // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false;    // ��� ����
    private Rigidbody2D playerRigidbody;    // ����� ������ٵ� ������Ʈ
    private Animator animator;  // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio;    // ����� ����� �ҽ� ������Ʈ

    private void Start()    // �ʱ�ȭ
    {
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()   // ����� �Է��� �����ϰ� �����ϴ� ó��
    {
        if (isDead) 
        {
            return; // ��� �� ó���� �� �̻� �������� �ʰ� ����
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)   // ���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        {
            jumpCount++;    // ���� Ƚ�� ����
            playerRigidbody.velocity = Vector2.zero;    // ���� ������ �ӵ��� ���������� ����(0, 0)�� ����
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)  // ���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y ���� ������(���� ��� ��)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; // ������ �ӵ��� �������� ����
        }

        animator.SetBool("Grounded", isGrounded);   // �ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
    }

    private void Die()  // ��� ó��
    {
        animator.SetTrigger("Die"); // �ִϸ������� Die Ʈ���� �Ķ���͸� ��

        playerAudio.clip = deathClip;   // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.Play(); // ��� ȿ���� ���

        playerRigidbody.velocity = Vector2.zero;    // �ӵ��� ����(0, 0)�� ����
        isDead = true;  // ��� ���¸� true�� ����
    }

    private void OnTriggerEnter2D(Collider2D other) // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    {
        if (other.tag == "Dead" && !isDead) // �浹�� ������� �±װ� Dead�̸� ���� ������� �ʾҴٸ�
        {
            Die();  // Die() ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // �ٴڿ� ������� �����ϴ� ó��
    {
        if (collision.contacts[0].normal.y > 0.7f)  // � �ݶ��̴��� ������� �浹 ǥ���� ������ ���� ������
        {
            isGrounded = true;  // isGrounded�� true�� �����ϰ�
            jumpCount = 0;  // ���� ���� Ƚ���� 0���� ����
        }
    }

    private void OnCollisionExit2D(Collision2D collision)   // �ٴڿ��� ������� �����ϴ� ó��
    {
        isGrounded = false; // � �ݶ��̴����� ������ ��� isGrounded�� false�� ����
    }
}
