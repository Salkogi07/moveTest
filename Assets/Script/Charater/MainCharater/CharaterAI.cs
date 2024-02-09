using System.Collections;
using UnityEngine;

public class CharaterAI : MonoBehaviour
{
    public float move_delay_min;
    public float move_delay_max;  // ���� �̵������� ������ �ð�
    public int move_time;   // �̵� �ð�

    float speed_x;  // x�� ���� �̵� �ӵ�
    float speed_y;  // y�� ���� �̵� �ӵ�
    bool isWandering;
    bool isWalking;

    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        isWandering = false;
        isWalking = false;
    }

    void FixedUpdate()
    {
        if (!isWandering)
            StartCoroutine(Wander());   // �ڷ�ƾ ����
        if (isWalking)
            Move();
    }

    void Move()
    {
        // ĳ���� �̵�
        if (speed_x != 0)
            sprite.flipX = speed_x > 0; // x�� �ӵ��� ���� Sprite �̹����� ������

        transform.Translate(speed_x, speed_y, speed_y);  // ���� �̵�
    }

    IEnumerator Wander()
    {
        // Translate�� �̵��� �� Object�� �ڷ���Ʈ �ϴ� ���� �����ϱ� ���� Time.deltaTime�� ������
        speed_x = Random.Range(-0.8f, 0.8f) * Time.deltaTime;
        speed_y = Random.Range(-0.8f, 0.8f) * Time.deltaTime;

        isWandering = true;

        float move_delay = Random.Range(move_delay_min, move_delay_max);
        yield return new WaitForSeconds(move_delay);

        isWalking = true;
        anim.SetBool("isMoving", true);    // �̵� �ִϸ��̼� ����

        yield return new WaitForSeconds(move_time);

        isWalking = false;
        anim.SetBool("isMoving", false);    // �̵� �ִϸ��̼� ����

        isWandering = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bottom") || collision.gameObject.name.Contains("Top"))
            speed_y = -speed_y;
        else if (collision.gameObject.name.Contains("Left") || collision.gameObject.name.Contains("Right"))
            speed_x = -speed_x;
    }
}
