using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcFunction : MonoBehaviour
{
    [SerializeField] GameObject triggerText;
    [SerializeField] GameObject storePanel;

    bool isStoreActive = false;

    private void Update()
    {
        StartCoroutine(BuilidingStore());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        triggerText.SetActive(true);
        isStoreActive = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        triggerText.SetActive(false);
        isStoreActive = false;
    }

    IEnumerator BuilidingStore()
    {
        if (isStoreActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                triggerText.SetActive(false);
                storePanel.SetActive(true);
            }
        }
        yield return null;
    }
}
