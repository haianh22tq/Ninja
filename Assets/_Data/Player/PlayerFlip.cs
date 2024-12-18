using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public bool isFacingRight = false;
    public float moveInputDirection;

    private void Update()
    {
        moveInputDirection = Input.GetAxis("Horizontal");
    }
    public virtual void Flip()
    {
        if (isFacingRight && moveInputDirection > 0f || !isFacingRight && moveInputDirection < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
