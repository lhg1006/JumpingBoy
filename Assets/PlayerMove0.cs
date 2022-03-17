using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerMove0 : MonoBehaviour {


    bool isJumpManDead = false;
    bool isWalking = false;
    bool isJumping = false;
    Animator animator; //애니메이터 조작을 위한 변수 
    Rigidbody2D rigid;
    public float maxSpeed; //최대 속력 변수 
    SpriteRenderer spriteRenderer; //방향전환을 위한 변수 
    public float jumpPower;
    public JoystickValue value;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckJumpMandead());
        rigid = GetComponent<Rigidbody2D>(); //변수 초기화 
        spriteRenderer = GetComponent<SpriteRenderer>(); // 초기화 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
void Update() {

    transform.Translate(value.joyTouch);

    float h = Input.GetAxisRaw("Horizontal");   
    rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

    //Max speed Right
    if(rigid.velocity.x > maxSpeed)  //오른쪽으로 이동 (+) , 최대 속력을 넘으면 
        rigid.velocity= new Vector2(maxSpeed, rigid.velocity.y); //해당 오브젝트의 속력은 maxSpeed 
    
    //Max speed left
    else if(rigid.velocity.x < maxSpeed*(-1)) // 왼쪽으로 이동 (-) 
        rigid.velocity =  new Vector2(maxSpeed*(-1), rigid.velocity.y); //y값은 점프의 영향이므로 0으로 제한을 두면 안됨 

    // 버튼에서 손을 떄는 등의 단발적인 키보드 입력은 FixedUpdate보다 Update에 쓰는게 키보드 입력이 누락될 확률이 낮아짐
    //Stop speed 
    if(Input.GetButtonUp("Horizontal")){ // 버튼에서 손을 때는 경우 
        // normalized : 벡터 크기를 1로 만든 상태 (단위벡터 : 크기가 1인 벡터)
        // 벡터는 방향과 크기를 동시에 가지는데 크기(- : 왼 , + : 오)를 구별하기 위하여 
        // 단위벡터(1,-1)로 방향을 알수 있도록 단위벡터를 곱함 
        rigid.velocity = new Vector2( 0.5f * rigid.velocity.normalized.x , rigid.velocity.y);
        }
    //Direction Sprite
    if(Input.GetButtonDown("Horizontal")) // 방향키 입력이 들어오면 실행 
        spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // -1 (왼쪽이면, flipX true(체크))

    if(rigid.velocity.normalized.x==0) //속도가 0 == 멈춤 
        animator.SetBool("isWalking",false); //isWalking 변수 : false 
    else// 이동중 
        animator.SetBool("isWalking",true);

    //Jump
    if (Input.GetKeyDown (KeyCode.RightShift) && !animator.GetBool("isJumping")) {
        GetComponent<AudioSource>().Play();
        if (isJumping == false) {
        
            isJumping = true;

            GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 300f);
            
        }
        animator.SetBool("isJumping",true);
    }

    if (isJumpManDead) return;
}
    
    // 떨어지면 게임끝
    IEnumerator CheckJumpMandead()

    {
        while(true)
        {   // y 값이 -5보다 작아지면 
            if(transform.position.y < -5)
            {   // 3초 대기한다
                yield return new WaitForSeconds(3);
                // 씬 불러온다
                SceneManager.LoadScene("GameOverScene");
            }
            // 매 프레임의 마지막 마다 실행
            yield return new WaitForEndOfFrame();
        }
    }
    void OnCollisionEnter2D(Collision2D col) {

    // if (col.transform.name == "Background") {
    //     SceneManager.LoadScene("GameOverScene");
    // }
    if (col.transform.name == "boxdead") {
    boxdead.SoundPlay();
    }

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
    