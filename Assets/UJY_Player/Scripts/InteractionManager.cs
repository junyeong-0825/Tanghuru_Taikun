using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionManager : MonoBehaviour
{

    private float _maxCheckDistance = 1f;
    private Ray ray;
    private RaycastHit2D _raycastHit;
    private Vector2 _moveDir;
    private bool IsInteracting = false;
    public GameObject _promptText;



    private void Awake()
    {
        ray = new Ray();
    }

    private void FixedUpdate()
    {

        if(IsInteracting == false)
        {
            //��, ��, ��, �� Ű �Է¸��� ray ���� ��ȯ
            ray.origin = this.transform.position;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                _moveDir = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                _moveDir = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                _moveDir = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                _moveDir = Vector2.right;
           

            //hit�� ĳ��
            _raycastHit = Physics2D.Raycast(ray.origin, _moveDir, _maxCheckDistance, LayerMask.GetMask("Interactable"));

            if (_raycastHit.collider != null)
            {
                //hit�� ������Ʈ�� ������ ������ �� �ش� ������Ʈ ��ġ�� text �ű�� on
                Debug.Log(_raycastHit.collider.name);
                _promptText.transform.position = _raycastHit.collider.gameObject.transform.position;
                _promptText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    IsInteracting = true;
                    EffectManager.Instance.InteractingEffect(_raycastHit.collider.gameObject.transform);
                    _promptText.gameObject.SetActive(false);
                    //EŰ ������ ��ȣ�ۿ� ����, ��ȣ�ۿ� ������ �� IsInteracting�� false�� �ٲ�� ��
                }
            }
            else
            {
                _promptText.gameObject.SetActive(false);
            }
        }
       
    }

}


