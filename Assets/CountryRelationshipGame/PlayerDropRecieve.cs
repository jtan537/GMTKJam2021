using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropRecieve : MonoBehaviour
{
    public bool inDropOffPoint = false;
    public bool dropRecievePkg = false;

    // Update is called once per frame
    void Update()
    {
        if (inDropOffPoint && Input.GetKeyDown(KeyCode.E))
        {
            dropRecievePkg = true;
        }
    }
}
