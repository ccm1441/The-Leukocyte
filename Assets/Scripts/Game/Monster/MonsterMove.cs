using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMove : MonoBehaviour {
    public float movePower = 1f;//움직임 속도
    public float delayTime = 1f;//코루틴 딜레이시간
    Vector3 movement;


    public Transform player;
    public Transform monster;
    int movementFlag = 0;
    /* 몬스터가 범위내로 이동하기위한 변수선언*/
    public Transform corner_min;
    public Transform corner_max;
  
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;

    bool isTracing = false;
    // Use this for initialization
    void Awake()
    {
        x_max = corner_max.position.x;
        x_min = corner_min.position.x;
        y_max = corner_max.position.y;
        y_min = corner_min.position.y;
    }
    void Start ()
    {
        StartCoroutine("ChangeMovement");
	}
    private void KeepWithinMinMaxRectangle()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        

        float clampedX = Mathf.Clamp(x, x_min, x_max);
        float clampedY = Mathf.Clamp(y, y_min, y_max);
        

        transform.position = new Vector3(clampedX, clampedY, z);
       
    }
    // Update is called once per frame
    void FixedUpdate () {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";
        if (isTracing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, movePower * Time.deltaTime);
        }
        else
        {
            if (movementFlag == 1)
                dist = "Left";
            else if (movementFlag == 2)
                dist = "Right";
            else if (movementFlag == 3)
                dist = "Up";
            else if (movementFlag == 4)
                dist = "Down";
        }
        if(dist == "Left")
        {
            moveVelocity = Vector3.left;
            monster.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            monster.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dist == "Up")
        {
            moveVelocity = Vector3.up;
            monster.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(dist =="Down")
        {
            moveVelocity = Vector3.down;
            monster.transform.localScale = new Vector3(1, 1, 1);
        }
   
        monster.transform.position += moveVelocity * movePower * Time.deltaTime;
        KeepWithinMinMaxRectangle();
    }
    IEnumerator ChangeMovement()
    {
        
        movementFlag = Random.Range(0, 5);

        yield return new WaitForSeconds(delayTime);

        StartCoroutine("ChangeMovement");
    }
    void OnTriggerEnter2D(Collider2D other)
    { //플레이어 진입
        if (other.gameObject.tag == "Player")
            StopCoroutine("changMovement");
    }

    void OnTriggerStay2D(Collider2D other)
    { //플레이어 진입 후 원 안에 머물때
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    { // 플레이어 아웃
        if (this.gameObject.activeInHierarchy)
        {
            if (other.gameObject.tag == "Player")
            {
                isTracing = false;

                StartCoroutine("ChangeMovement");
            }
        }
    }
}
