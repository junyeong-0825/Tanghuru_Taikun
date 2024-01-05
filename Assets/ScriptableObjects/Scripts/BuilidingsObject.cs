using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data" , menuName = "BuilidingData")]
public class BuilidingsObject : ScriptableObject
{
    public int num; // ��ȣ
    public string builidingname;        // �̸�
    public Sprite sprite;       // �̹���
    public int price;   // ����
    public bool purchase; //���ſ���
    public Ingredients ingredients; // ���
    public int quantity;        // ����
}

public enum Ingredients
{
    Default,
    Stawberry,
    Orange,
    Grape
}
