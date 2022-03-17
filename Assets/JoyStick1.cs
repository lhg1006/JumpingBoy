using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject Character;
    public float moveSpeed;

    Rigidbody2D CharacterRigid;
    SpriteRenderer CharacterSprite;
    private void Start() {
        {
            CharacterRigid = Character.GetComponent<Rigidbody2D>();
            CharacterSprite = Character.GetComponent<SpriteRenderer>();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2(eventData.position.x, transform.position.y);

        if(transform.localPosition.x <-30)
        transform.localPosition = new Vector2(-30, 0);
        if(transform.localPosition.x > 30)
        transform.localPosition = new Vector2(30, 0);


        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("Move");
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        CharacterRigid.velocity = Vector2.zero;
        StopCoroutine("Move");
    }
    IEnumerator Move()
    {
        while(true)
        {
            if(transform.localPosition.x<0)
            {
            CharacterRigid.velocity = new Vector2(moveSpeed*-1, CharacterRigid.velocity.y);
            CharacterSprite.flipX = true;
            }
            if(transform.localPosition.x>0)
            {
            CharacterRigid.velocity = new Vector2(moveSpeed, CharacterRigid.velocity.y);
            CharacterSprite.flipX = false;
            }

            yield return null;
        }
    }
}
