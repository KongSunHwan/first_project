using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // 플레이어 속도를 제어합니다.
    public float jumpForce; // 점프의 힘을 제어한다.
    public CharacterController controller;

    private Vector3 moveDirection;// 이렇게 하면 정보가 저장되고 문자 컨트롤러에 정보가 제공됩니다.
    public float gravityScale; // 중력을 조정하여 플레이어가 더 빨리 넘어지도록 합니다.

    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    public bool robertoIsSwimming;

    public GameMgr gameMgr;


    // 첫 번째 프레임 업데이트 전에 Start가 호출됩니다.
    void Start()
    {
        controller = GetComponent<CharacterController>(); //객체에서 문자 컨트롤러 찾기
        robertoIsSwimming = false;
    }

    // 업데이트는 프레임당 한 번씩 호출됩니다.
    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        
        if (controller.isGrounded & robertoIsSwimming == false) // 플레이어가 접지된 경우에만 점프할 수 있습니다.
        {
            anim.SetBool("IsGrounded", true);
            moveDirection.y = 0f; // 접지된 상태에서 중력을 비활성화합니다.
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;    // 점프 설정.
                anim.SetBool("IsGrounded", false);
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); // 중력 추가.
        controller.Move(moveDirection * Time.deltaTime); // 실제로 이동 정보를 수신하도록 컨트롤러를 설정합니다.

        // 카메라 모양 방향에 따라 플레이어를 다른 방향으로 이동합니다.
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        //애니메이션 부울과 스피드 플로트 설정.
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))));

    }


    // 애니메이션 파라미터에 물을 공급합니다.
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            anim.SetBool("IsSwimming", true);
            robertoIsSwimming = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            anim.SetBool("IsSwimming", false);
            robertoIsSwimming = false;
        }
    }
}