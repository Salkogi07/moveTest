using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Animator anim;
    private CharacterSet characterSet;

    [SerializeField] private float playNum = 0;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Collider2D boundaryCharacterCollider;
    [SerializeField] private Collider2D boundaryMouseCollider;

    private Vector3 mousePos, transPos, targetPos;
    private Vector3 previousPosition;
    private float horizontalDirection = 0;
    private int facingDir = 1;
    private bool facingRight = true;

    private void Start()
    {
        previousPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
        characterSet = GameObject.Find("PlayManager").GetComponent<CharacterSet>();

        targetPos = transform.position;
    }

    private void Update()
    {
        CheckInputMouse();
        CheckHorizontal();
        CheckRestrictedArea();
        MoveToTarget();
        FlipController();
        AnimatorControllers();
    }

    private void CheckInputMouse()
    {
        if (playNum == characterSet.currentPlayNum && Input.GetMouseButtonDown(0))
        {
            CalTargetPos();
        }
    }

    private void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);

        // 허용 범위 내에 클릭되었을 때만 이동
        if (boundaryMouseCollider != null && !boundaryMouseCollider.OverlapPoint(targetPos))
        {
            // 제한 구역 밖을 클릭했을 때는 현재 위치로 설정
            targetPos = transform.position;
        }
    }

    private void CheckRestrictedArea()
    {
        if (boundaryCharacterCollider != null)
        {
            Vector3 clampedPosition = boundaryCharacterCollider.ClosestPoint(targetPos);
            targetPos.x = clampedPosition.x;
            targetPos.y = clampedPosition.y;
        }
    }

    private void MoveToTarget()
    {
        // 여기서 수정: 정확한 위치에 도달했을 때만 이동
        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
        }
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (horizontalDirection < 0 && !facingRight)
            Flip();
        else if (horizontalDirection > 0 && facingRight)
            Flip();
    }

    private void AnimatorControllers()
    {
        bool isMoving = horizontalDirection != 0;
        anim.SetBool("isMoving", isMoving);
    }

    private void CheckHorizontal()
    {
        Vector3 movementDirection = (transform.position - previousPosition).normalized;
        horizontalDirection = Mathf.Approximately(movementDirection.x, 0) ? 0 : Mathf.Sign(movementDirection.x);
        previousPosition = transform.position;
    }
}
