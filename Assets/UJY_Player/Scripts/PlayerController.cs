using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //�̵� �̺�Ʈ ���� ����
    public event Action<Vector2> OnMoveEvent;
    public SpriteRenderer spriteRenderer;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }


    //�̵� �̺�Ʈ ȣ�� �Լ�
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    //InputSystem �Է½� Value �޾Ƽ� �̺�Ʈȣ�� �Լ� ȣ��
    public void OnMove(InputValue value)
    {
        //��ǲ�ý��� ���� �������Ͱ����� ���� �� �Ű������� �����ϸ鼭 �����̺�Ʈ �Լ� ȣ��
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);


        //��ǲ�ý����� x���� ������ ���ϸ� y������ ������ ����� �ٲ� �� �ٽ� �����·� ���ư����� �ϱ�
        if (moveInput.x > 0)
        {
            spriteRenderer.flipY = false;
        }

        if (moveInput.x < 0)
        {
            spriteRenderer.flipY = true;
        }

    }

 

}
