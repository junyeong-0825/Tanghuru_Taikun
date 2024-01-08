using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MachineType
{
    Production,
    Sale
}

[CreateAssetMenu(fileName = "Machine", menuName = "new Machine")]
public class MachineData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public MachineType type;
    public Sprite icon;
}
