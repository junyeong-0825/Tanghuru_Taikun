using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnInteract();
}
public class InteractionManager : MonoBehaviour
{
    public GameObject TempGameObject;
    
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    private GameObject curInteractGameobject;
    private IInteractable curInteractable;

    private void OnCollisionEnter2D(Collision2D hit)
    {
        GameObject hitGameObject = hit.gameObject;

        int hitLayer = hit.gameObject.layer;

        switch (hitLayer)
        {
            case 30: //재료와의 상호작용 레이어(ingredients)
                if (hit.gameObject != curInteractGameobject)
                {
                    curInteractGameobject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    InteractionWithItem();
                }
                break;
            case 31: //설치물과의 상호작용 레이어(Machine)
                if (hit.gameObject != curInteractGameobject)
                {
                    curInteractGameobject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    InteractionWithItem();
                }
                break;
        }
        

    }

    private void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.collider.gameObject == curInteractGameobject)
        {
            curInteractGameobject = null;
            curInteractable = null;
        }
    }
    
    private void InteractionWithItem()
    {
        if (curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameobject = null;
            curInteractable = null;
        }
    }
}
