using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteractController : MonoBehaviour
{

    private Ray ray;
    private RaycastHit2D _raycastHit;
    private Vector2 _moveDir;
    private float _maxCheckDistance = 1f;
    private bool IsInteracting = false;
    private PlayerItemDataController _playerItemDataController;
    private GameObject player;

    public GameObject PromptText;
    public GameObject QuestList;
    public GameObject Inventory;
    public GameObject ChoiceFruit;
    public GameObject Farm;
    public GameObject Shop;


    private void Awake()
    {
        ray = new Ray();
        player = GameObject.FindGameObjectWithTag("Player");
        _playerItemDataController = player.GetComponent<PlayerItemDataController>();
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (QuestList.activeSelf == true)
                QuestList.SetActive(false);
            else if (QuestList.activeSelf == false)
                QuestList.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Farm.activeSelf == true)
                Farm.SetActive(false);
            else if (Farm.activeSelf == false)
                Farm.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Shop.activeSelf == true)
                Shop.SetActive(false);
            else if (Shop.activeSelf == false)
                Shop.SetActive(true);
        }


        if (IsInteracting == false)
        {
            //��, ��, ��, �� Ű �Է¸��� ray ���� ��ȯ
            ray.origin = this.transform.position;
            if (Input.GetKeyDown(KeyCode.W))
                _moveDir = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.S))
                _moveDir = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.A))
                _moveDir = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.D))
                _moveDir = Vector2.right;
           

            //hit�� ĳ��, layermask�� ���Ͽ� ��ȣ�ۿ� ���� ��ü �Ǵ� / ������ �پ��� �� �з��� TAG�� �� ����
            _raycastHit = Physics2D.Raycast(ray.origin, _moveDir, _maxCheckDistance, LayerMask.GetMask("Interactable"));

            if (_raycastHit.collider != null)
            {
                //hit�� ������Ʈ�� ������ ������ �� �ش� ������Ʈ ��ġ�� text �ű�� on
                PromptText.transform.position = _raycastHit.collider.gameObject.transform.position;
                PromptText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    EffectManager.Instance.InteractingEffect(_raycastHit.collider.gameObject.transform);
                    PromptText.gameObject.SetActive(false);
                    if (_raycastHit.collider.gameObject.tag == "CookObject")
                        Cooking(_raycastHit.collider.gameObject.name);
                    else if (_raycastHit.collider.gameObject.tag == "ResourceObject")
                        FarmOpen();
                    else if (_raycastHit.collider.gameObject.tag == "DisplayObject")
                        // _raycastHit.collider.gameObject;
                        Display(_raycastHit.collider.gameObject.name);
                    else if (_raycastHit.collider.gameObject.tag == "ShopObject")
                        ShopOpen();

                }
            }
            else
            {
                PromptText.gameObject.SetActive(false);
            }
        }
       
    }


    private void Cooking(string name)
    {
        switch(name)
        {
            case "Maker":
                ChoiceFruit.SetActive(true);
                break;
        }
    }

    private void Display(string name)
    {
        switch (name)
        {
            case "StrawberryTable":
                _playerItemDataController.DisplayItem(Displays.DISPLAY1);
                break;
            case "Table2":
                _playerItemDataController.DisplayItem(Displays.DISPLAY2);
                break;
            case "Table3":
                _playerItemDataController.DisplayItem(Displays.DISPLAY3);
                break;
            case "Table4":
                _playerItemDataController.DisplayItem(Displays.DISPLAY4);
                break;
            case "Table5":
                _playerItemDataController.DisplayItem(Displays.DISPLAY5);
                break;
        }
    }


    private void FarmOpen()
    {
        Farm.SetActive(true);
    }

    private void ShopOpen()
    {
        Shop.SetActive(true);
    }


}


