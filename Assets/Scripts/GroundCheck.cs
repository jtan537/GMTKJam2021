using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    public void OnTriggerEnter2D(Collider2D collider){
        // Check if layer ground check entered is ground layer
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Ground"){
            isGrounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider){
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Ground"){
            isGrounded = false;
        }
    }
}
