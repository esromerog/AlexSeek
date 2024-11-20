using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsUp : MonoBehaviour
{
    BoxCollider2D boxCollider;
    BoxCollider2D playerCollider;

    GameObject hero;

    void Start() {
        boxCollider=GetComponent<BoxCollider2D>();
        hero = GameObject.Find("hero");
        playerCollider = hero.GetComponent<BoxCollider2D>();
    }

    void Update() {
        OnCollide();
    }

    protected virtual void OnCollide() {
        bool facingNPC=hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("WalkBack");
        if (boxCollider.bounds.Intersects(playerCollider.bounds)) {
            Debug.Log("Entered Collision");
            if (gameObject.name=="Stairs"){
                SceneManager.LoadScene("Floor2");
                Debug.Log("Go Up");
            }

            else if (gameObject.name=="StairsDown") {
                SceneManager.LoadScene("Main");
                GameManager.instance.hasLoadedTwice=true;
            }

            else if (gameObject.name=="DarkRoomEntrance"){
                Debug.Log("A ver");
                if (GameManager.instance.blasInteraction) {
                    SceneManager.LoadScene("DarkRoomLit");
                }
                else {
                    SceneManager.LoadScene("DarkRoom1");
                }
            }
        }
    }
}
