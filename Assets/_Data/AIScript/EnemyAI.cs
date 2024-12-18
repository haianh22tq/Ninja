using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float circleRadius;
    [SerializeField]
    private Rigidbody2D enemyRB;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public bool facingRight = true;
    public bool isGrounded = true;

    private void Start()
    {
        enemyRB = transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        enemyRB.velocity = Vector2.right * speed * Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadius, groundLayer);
        if (!isGrounded && facingRight)
        {
            Flip();
        }
        else if (!isGrounded && !facingRight)
        {
            Flip();
        }
    }
    public virtual void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        speed = -speed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadius);
    }


}
