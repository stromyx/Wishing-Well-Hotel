using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{
    void OnMouseDown()
    {
        Player.Instance.GetItemToInventory();
        Debug.Log("Clicked");
    }
}
