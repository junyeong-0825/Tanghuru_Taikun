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
            //상, 하, 좌, 우 키 입력마다 ray 방향 전환
            ray.origin = this.transform.position;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                _moveDir = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                _moveDir = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                _moveDir = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                _moveDir = Vector2.right;
           

            //hit값 캐싱
            _raycastHit = Physics2D.Raycast(ray.origin, _moveDir, _maxCheckDistance, LayerMask.GetMask("Interactable"));

            if (_raycastHit.collider != null)
            {
                //hit한 오브젝트의 포지션 가져온 후 해당 오브젝트 위치에 text 옮기고 on
                Debug.Log(_raycastHit.collider.name);
                PromptText.transform.position = _raycastHit.collider.gameObject.transform.position;
                PromptText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    IsInteracting = true;
                    EffectManager.Instance.InteractingEffect(_raycastHit.collider.gameObject.transform);
                    PromptText.gameObject.SetActive(false);
                    //E키 누르면 상호작용 진행, 상호작용 마무리 후 IsInteracting을 false로 바꿔야 함
                }
            }
            else
            {
                PromptText.gameObject.SetActive(false);
            }
        }
       
    }

}


