using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToBackpack : MonoBehaviour
{
    public GameObject backpack;
    public GameObject itself;
    // Start is called before the first frame update

    public void GetTo()
    {
        itself.transform.localPosition = Vector3.MoveTowards(itself.transform.localPosition, backpack.transform.localPosition, 1000);

    }





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
