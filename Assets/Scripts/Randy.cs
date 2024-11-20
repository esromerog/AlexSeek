using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randy : NPCInteraction {
    public string preInteractionDialogue;
    public string postInteractionDialogue;
    public string idleDialogue;
    private GameObject bookshelf;
    protected override void Start()
    {
        base.Start();
        orientation.Add("IdleBack");
        orientation.Add("WalkBack");
        bookshelf=GameObject.Find("Bookshelf");
    }
    void Update(){
        if (hasInteracted[1]||GameManager.instance.randyInteraction) {
            Speech(idleDialogue,3);
        } else if (hasInteracted[0]&bookshelf.GetComponent<Bookshelf>().hasInteracted[0]&GameManager.instance.levanaInteraction) {
            Speech(postInteractionDialogue,1);
            GameManager.instance.randyInteraction=hasInteracted[1];
        } else {
            Speech(preInteractionDialogue,0);
        }
    }
}
