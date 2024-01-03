using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data" , menuName = "BuilidingData")]
public class BuilidingsObject : ScriptableObject
{
    public string Builidingname;
    public Sprite sprite;
    public int price;
}
