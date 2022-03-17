using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator ani;
    public float jumpSpeed;
    bool jumping;
    private void Start() 
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    public void JumpBtn(){
        if(!jumping)
        {
            jumping = true;
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            ani.Play("Jumping");
            GetComponent<AudioSource>().Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag=="Ground")
        {
            jumping = false;
            ani.Play("Character");
        }
    }

}
