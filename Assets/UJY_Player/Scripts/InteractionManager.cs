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

    public GameObject _promptText;



    private void Awake()
    {
        ray = new Ray();
    }

    private void Update()
    {
        ray.origin = this.transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow))
            _moveDir = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            _moveDir = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            _moveDir = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            _moveDir = Vector2.right;

        _raycastHit = Physics2D.Raycast(ray.origin, _moveDir, _maxCheckDistance, LayerMask.GetMask("Interactable"));

        if (_raycastHit.collider != null)
        {
            Debug.Log(_raycastHit.collider.name);
            _promptText.transform.position = _raycastHit.collider.gameObject.transform.position;
            _promptText.gameObject.SetActive(true);
        }
        else
        {
            _promptText.gameObject.SetActive(false);
        }

    }

}


