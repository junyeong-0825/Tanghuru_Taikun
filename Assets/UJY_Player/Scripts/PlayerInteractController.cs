using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteractController : MonoBehaviour
{

    private float _maxCheckDistance = 1f;
    private Ray ray;
    private RaycastHit2D _raycastHit;
    private Vector2 _moveDir;
    private bool IsInteracting = false;
    public GameObject PromptText;
    public GameObject Inventory;
    public GameObject Farm;


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
            //상, 하, 좌, 우 키 입력마다 ray 방향 전환
            ray.origin = this.transform.position;
            if (Input.GetKeyDown(KeyCode.W))
                _moveDir = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.S))
                _moveDir = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.A))
                _moveDir = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.D))
                _moveDir = Vector2.right;
           

            //hit값 캐싱, layermask로 비교하여 상호작용 가능 물체 판단 / 종류가 다양할 시 분류는 TAG로 할 예정
            _raycastHit = Physics2D.Raycast(ray.origin, _moveDir, _maxCheckDistance, LayerMask.GetMask("Interactable"));

            if (_raycastHit.collider != null)
            {
                //hit한 오브젝트의 포지션 가져온 후 해당 오브젝트 위치에 text 옮기고 on
                PromptText.transform.position = _raycastHit.collider.gameObject.transform.position;
                PromptText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    EffectManager.Instance.InteractingEffect(_raycastHit.collider.gameObject.transform);
                    PromptText.gameObject.SetActive(false);
                    if (_raycastHit.collider.gameObject.tag == "CookObject")
                        Cooking();
                    else if (_raycastHit.collider.gameObject.tag == "ResourceObject")
                        GetResources();
                    else if (_raycastHit.collider.gameObject.tag == "DisplayObject")
                        Display();

                }
            }
            else
            {
                PromptText.gameObject.SetActive(false);
            }
        }
       
    }


    private void Cooking()
    {
        Debug.Log("Cooking");
        Player.Instance.Cooking(Resources.RESOURCE1);
    }

    private void Display()
    {
        Debug.Log("Display");
        Player.Instance.DisplayItem(Items.ITEM1);
    }


    private void GetResources()
    {
        Debug.Log("GetResource");
        Farm.SetActive(true);
    }


}


