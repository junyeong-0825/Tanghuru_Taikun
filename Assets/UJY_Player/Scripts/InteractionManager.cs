using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteractionController : MonoBehaviour
{

    private float _maxCheckDistance = 1f;
    private Ray ray;
    private RaycastHit2D _raycastHit;
    private Vector2 _moveDir;
    private bool IsInteracting = false;
    public GameObject PromptText;
    public GameObject Inventory;



    private void Awake()
    {
        ray = new Ray();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(Inventory.activeSelf == true)
            Inventory.SetActive(false);
            else if(Inventory.activeSelf == false)
                Inventory.SetActive(true);
        }


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
           

            //hit�� ĳ��, layermask�� ���Ͽ� ��ȣ�ۿ� ���� ��ü �Ǵ� / ������ �پ��� �� �з��� TAG�� �� ����
            _raycastHit = Physics2D.Raycast(ray.origin, _moveDir, _maxCheckDistance, LayerMask.GetMask("Interactable"));

            if (_raycastHit.collider != null)
            {
                //hit�� ������Ʈ�� ������ ������ �� �ش� ������Ʈ ��ġ�� text �ű�� on
                Debug.Log(_raycastHit.collider.name);
                PromptText.transform.position = _raycastHit.collider.gameObject.transform.position;
                PromptText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //IsInteracting = true;
                    EffectManager.Instance.InteractingEffect(_raycastHit.collider.gameObject.transform);
                    PromptText.gameObject.SetActive(false);
                    //EŰ ������ ��ȣ�ۿ� ����, ��ȣ�ۿ� ������ �� IsInteracting�� false�� �ٲ�� ��
                }
            }
            else
            {
                PromptText.gameObject.SetActive(false);
            }
        }
       
    }

}


