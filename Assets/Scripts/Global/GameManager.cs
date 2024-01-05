using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject InGameObject;
    public GameObject UIObject;
    public GameObject GlobalObject;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Instantiate(GlobalObject);
        //Instantiate(InGameObject);
        //Instantiate(UIObject);
    }

}
