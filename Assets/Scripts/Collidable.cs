using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collidable : MonoBehaviour
{

    protected bool playerInteraction=false;

    protected virtual void Start() {

    }

    protected void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag=="hero"){
            playerInteraction=true;
            Debug.Log("Began Hero Collision");
        }
        Debug.Log("Collision");
    }

    protected void OnCollisionExit2D(Collision2D coll) {
        if (coll.gameObject.tag=="hero"){
            playerInteraction=false;
            Debug.Log("Exit Hero Collision");
        }
    }

}
