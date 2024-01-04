
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuilngData : MonoBehaviour
{
    [Header("Builing")]
    public List<GameObject> buildings;
    public List<Button> buildingButtons;

    private void Start()
    {
        for (int i = 0; i < buildingButtons.Count; i++)
        {
            int index = i;

            buildingButtons[index].onClick.AddListener(() => BuildingActive(index));
        }
    }
    public void BuildingActive(int index)
    {
        if (index >= 0 && index < buildings.Count)
        {
            buildings[index].SetActive(true);
        }
    }
}
