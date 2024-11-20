using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    protected BoxCollider2D playerCollider;
    protected GameObject hero;
    protected bool isColliding;
    protected Animator anim;
    protected List<int> dialogueCount=new List<int>();
    public List<bool> hasInteracted=new List<bool>();
    protected List<string> orientation=new List<string>();
    private bool hasTalked=false;
    public FloatingTextManager floatingTextManager;

    protected virtual void Start() {
        boxCollider=GetComponent<BoxCollider2D>();
        hero = GameObject.Find("hero");
        playerCollider = hero.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        for (int i = 0; i < 10; i++)
        {
            dialogueCount.Add(0);
            hasInteracted.Add(false);
        }
    }

    public virtual void Speech(string dialogue,int dialogueNum) {
        OnCollide();
        if (isColliding) {
            if (ButtonInteraction()){
                if (!hasTalked) {
                    hasInteracted[dialogueNum]=floatingTextManager.Show(dialogue,dialogueCount[dialogueNum]);
                    dialogueCount[dialogueNum]+=1;
                    hasTalked=hasInteracted[dialogueNum];
                    Debug.Log("Completed");
                }
            } else if (hasTalked) {
                hasTalked=false;
                dialogueCount[dialogueNum]=0;
            }
        }
    }

    protected virtual void OnCollide() {
        bool facingNPC=false;
        foreach (string test in orientation) {
            if (hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(test)){
                facingNPC=true;
            }
        }
        
        if (boxCollider.bounds.Intersects(playerCollider.bounds) && facingNPC) {
            Debug.Log("Conditions met");
            if (!isColliding) {
                Debug.Log("Entered Collision");
                try{anim.SetBool("Interacting",true);}
                catch{}
                isColliding=true;
            }
        } else if(isColliding) {
            isColliding=false;
            Debug.Log("Left Collision");
            try{anim.SetBool("Interacting",false);}
            catch{}
        }
    }

    protected virtual bool ButtonInteraction() {
        bool action;
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0")) {
            hero.GetComponent<Player>().interacting=true;
            action=true;
            Debug.Log("Interaction...");
        } else {
            action=false;
        }
        return action;
    }

}
