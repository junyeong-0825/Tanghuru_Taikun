using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data" , menuName = "BuilidingData")]
public class BuilidingsObject : ScriptableObject
{
    public int num; // 번호
    public string builidingname;        // 이름
    public Sprite sprite;       // 이미지
    public int price;   // 가격
    public bool purchase; //구매여부
    public Ingredients ingredients; // 재료
    public int quantity;        // 수량
}

public enum Ingredients
{
    Default,
    Stawberry,
    Orange,
    Grape
}
