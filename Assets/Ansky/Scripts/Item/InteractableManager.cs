using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();
}
public class InteractableManager : MonoBehaviour
{
    public LayerMask layermask;
    public TextMeshProUGUI promptText;
    
    private GameObject curInteractGameobject;
    private IInteractable curInteractable;
    
    
}
