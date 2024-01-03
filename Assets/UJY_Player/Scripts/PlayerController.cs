using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //�̵� �̺�Ʈ ���� ����
    public event Action<Vector2> OnMoveEvent;
    private GameObject _mainSprite;
    private GameObject _mainSpriteUp;
    private GameObject _mainSpriteDown;
    private SpriteRenderer _spriteRenderer;

 
    private Camera _camera;

    private void Awake()
    {
        _mainSprite = transform.GetChild(0).gameObject;
        _mainSpriteUp = transform.GetChild(1).gameObject;
        _mainSpriteDown = transform.GetChild(2).gameObject;
        _spriteRenderer = _mainSprite.GetComponent<SpriteRenderer>();
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

        
        //��ǲ�ý����� x���� 0�� �� y���� ���� ��, �޸������ ��������Ʈ ����
        if (moveInput.x == 0)
        {
            if (moveInput.y > 0)
            {
                _mainSprite.SetActive(false);
                _mainSpriteDown.SetActive(false);
                _mainSpriteUp.SetActive(true);
            }

            if (moveInput.y < 0)
            {
                _mainSprite.SetActive(false);
                _mainSpriteDown.SetActive(true);
                _mainSpriteUp.SetActive(false);
            }
        }
        else
        {
            //��, �� ������� ���� �� ��ǲ�ý����� x���� ������ ���ϸ� y������ ������ ����� �ٲ� �� �ٽ� �����·� ���ư����� �ϱ�
            _mainSpriteDown.SetActive(false);
            _mainSpriteUp.SetActive(false);
            _mainSprite.SetActive(true);
            if (moveInput.x > 0)
            {

                _spriteRenderer.flipX = false;
            }

            if (moveInput.x < 0)
            {
             
                _spriteRenderer.flipX = true;
            }
        }


    }

 

}
