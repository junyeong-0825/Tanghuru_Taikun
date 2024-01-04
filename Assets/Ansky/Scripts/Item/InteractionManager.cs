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
        if (hit.collider.gameObject != curInteractGameobject)
        {
            curInteractGameobject = hit.collider.gameObject;
            curInteractable = hit.collider.GetComponent<IInteractable>();
            InteractionWithItem();
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
