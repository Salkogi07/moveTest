using System.Collections;
using UnityEngine;

public class CharaterAI : MonoBehaviour
{
    public float move_delay_min;
    public float move_delay_max;  // 다음 이동까지의 딜레이 시간
    public int move_time;   // 이동 시간

    float speed_x;  // x축 방향 이동 속도
    float speed_y;  // y축 방향 이동 속도
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
            StartCoroutine(Wander());   // 코루틴 실행
        if (isWalking)
            Move();
    }

    void Move()
    {
        // 캐릭터 이동
        if (speed_x != 0)
            sprite.flipX = speed_x > 0; // x축 속도에 따라 Sprite 이미지를 뒤집음

        transform.Translate(speed_x, speed_y, speed_y);  // 젤리 이동
    }

    IEnumerator Wander()
    {
        // Translate로 이동할 시 Object가 텔레포트 하는 것을 방지하기 위해 Time.deltaTime을 곱해줌
        speed_x = Random.Range(-0.8f, 0.8f) * Time.deltaTime;
        speed_y = Random.Range(-0.8f, 0.8f) * Time.deltaTime;

        isWandering = true;

        float move_delay = Random.Range(move_delay_min, move_delay_max);
        yield return new WaitForSeconds(move_delay);

        isWalking = true;
        anim.SetBool("isMoving", true);    // 이동 애니메이션 실행

        yield return new WaitForSeconds(move_time);

        isWalking = false;
        anim.SetBool("isMoving", false);    // 이동 애니메이션 종료

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
