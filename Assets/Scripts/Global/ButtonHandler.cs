using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void GetStrawberryBtn()
    {
        Player.Instance.GetResource(Resources.RESOURCE1);
    }

}
