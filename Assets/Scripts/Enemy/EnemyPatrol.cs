using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float patrolSpeed = 2f;
    [SerializeField] float waitTime = 1f;

    private int currentPointIndex = 0;
    private Rigidbody2D rb;
    private bool isWaiting = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[0].position;
        }
    }
    private void FixedUpdate()
    {
        if (patrolPoints.Length < 2 || isWaiting) return;
        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector2 direction = (targetPoint.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * patrolSpeed, rb.linearVelocityY);
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            StartCoroutine(WaitAndSwitchPoint());
        }
    }
    private IEnumerator WaitAndSwitchPoint()
    {
        isWaiting = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(waitTime);
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        isWaiting = false;
    }
}
