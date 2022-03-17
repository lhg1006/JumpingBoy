using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonA : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Animator animator; //애니메이터 조작을 위한 변수 
    bool isJumping = false;
    public PlayerMove0 playerMove0;
    public JoystickValue value;
    public void OnPointerDown(PointerEventData eventData)
    {
        value.aTouch = true;
            //Jump
    if (Input.GetKeyDown (KeyCode.RightShift) && !animator.GetBool("isJumping")) {
        GetComponent<AudioSource>().Play();
        if (isJumping == false) {
        
            isJumping = true;

            GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 300f);
            
        }
        animator.SetBool("isJumping",true);
    }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        value.aTouch = false;
    }
 void OnCollisionEnter2D(Collision2D col) {

    if (col.transform.name == "Ground") {
        animator.SetBool("isJumping",false);

        isJumping = false;
        }
    if (col.transform.name == "Stage") {
        animator.SetBool("isJumping",false);

        isJumping = false;
        }
    if (col.transform.name == "Ground(Clone)") {
        animator.SetBool("isJumping",false);

        isJumping = false;
        }
    }

}
