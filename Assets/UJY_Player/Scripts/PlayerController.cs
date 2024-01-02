using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //이동 이벤트 변수 선언
    public event Action<Vector2> OnMoveEvent;
    public SpriteRenderer spriteRenderer;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }


    //이동 이벤트 호출 함수
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    //InputSystem 입력시 Value 받아서 이벤트호출 함수 호출
    public void OnMove(InputValue value)
    {
        //인풋시스템 값을 단위벡터값으로 변경 후 매개변수로 전달하면서 무브이벤트 함수 호출
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);


        //인풋시스템의 x값이 0일 때 y값에 따라 앞, 뒷모습으로 스프라이트 변경
        if (moveInput.x == 0)
        {
            if (moveInput.y > 0)
            {
                Debug.Log("위");
                //뒷모습이 보이는 스프라이트로 변경
            }

            if (moveInput.y < 0)
            {
                Debug.Log("아래");
                //앞모습이 보이는 스프라이트로 변경
            }
        }
        else
        {
            //인풋시스템의 x값이 음수로 변하면 y축으로 뒤집고 양수로 바뀔 때 다시 원상태로 돌아가도록 하기
            if (moveInput.x > 0)
            {
                Debug.Log("오른쪽");
                spriteRenderer.flipY = false;
            }

            if (moveInput.x < 0)
            {
                Debug.Log("왼쪽");
                spriteRenderer.flipY = true;
            }
        }


    }

 

}
