using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public bool isSliding = false;
    public PlayerMovement playerMovement;
    public Rigidbody2D rb2d;
    public Animator anim;

    public float slideSpeed = 5f;

    public BoxCollider2D regularColl;
    public BoxCollider2D flashColl;

    private void Start()
    {
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this.PlayerFlash();
    }

    protected virtual void PlayerFlash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; // khoa truc y
            this.prefromSlide();
        }
    }

    protected virtual void prefromSlide()
    {
        isSliding = true;
        anim.SetBool("slide", true);

        regularColl.enabled = false;
        regularColl.isTrigger = true;
        flashColl.isTrigger = true;
        StartCoroutine("stopSlide");

        if (!playerMovement.isFacingRight)
        {
            rb2d.AddForce(Vector2.right * slideSpeed);
        }
        else
        {
            rb2d.AddForce(Vector2.left * slideSpeed);
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.3f);
        //anim.Play("player_Idle");
        anim.Play("Movement");
        anim.SetBool("slide", false);

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; // mo truc y

        regularColl.enabled = true;
        regularColl.isTrigger = false;
        flashColl.isTrigger = false;
        //slideColl.enabled = true;
        isSliding = false;
    }
}