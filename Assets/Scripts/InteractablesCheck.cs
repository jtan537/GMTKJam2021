using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Checks if package is in interaction range
public class InteractionCheck : MonoBehaviour
{
    public bool packageInRange;

    public void OnTriggerEnter2D(Collider2D collider){
        if(LayerMask.LayerToName(collider.gameObject.layer) == "Interactables"){
            packageInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider){
        if(LayerMask.LayerToName(collider.gameObject.layer) == "Interactables"){
            packageInRange = true;
        }
    }
}
