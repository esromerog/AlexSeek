using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private Animator anim;
    private RaycastHit2D hit;
    private Vector3 colliderCenter;

    public bool interacting=false;

    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        if (GameManager.instance.hasLoadedTwice==true&&SceneManager.GetActiveScene().name=="Main"){
            transform.position=new Vector3(-0.565f,0.676f,0f);
        }
    }

    private void FixedUpdate() {
        
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        moveDelta = new Vector3(x,y,0);
        
        colliderCenter = new Vector3(transform.position.x+boxCollider.offset.x,transform.position.y+boxCollider.offset.y,0);

        if (interacting) {
            moveDelta = Vector3.zero;
        }

        else if (y>0.5 || y<-0.5) {
            hit = Physics2D.BoxCast(colliderCenter,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y*Time.deltaTime),LayerMask.GetMask("Block","Character"));

            if (hit.collider == null) {
                transform.Translate(0,moveDelta.y * Time.deltaTime,0);
            }

            anim.SetFloat("Horizontal",0);
            anim.SetFloat("Vertical",y);
        }
        else {
            hit = Physics2D.BoxCast(colliderCenter,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x*Time.deltaTime),LayerMask.GetMask("Block","Character"));

            if (hit.collider == null) {
                transform.Translate(moveDelta.x * Time.deltaTime,0,0);
            }
            anim.SetFloat("Horizontal",x);
            anim.SetFloat("Vertical",0);
        }
    }
}
