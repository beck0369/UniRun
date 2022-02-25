using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ����
    public Text scoreText;  // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI;   // ���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0;  // ���� ����

    private void Awake()    // ���� ���۰� ���ÿ� �̱����� ����
    {
        if (instance == null)   // �̱��� ���� instance�� ��� �ִ°�?
        {
            instance = this;    // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    private void Update()   // ���ӿ��� ���¿��� ������ ������� �� �ְ� �ϴ� ó��
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            // ���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ���ϸ� ���� �� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)  // ������ ������Ű�� �޼���
    {

    }

    public void OnPlayerDead()  // �÷��̾� ĳ���� ��� �� ���ӿ����� �����ϴ� �޼���
    {

    }
}
