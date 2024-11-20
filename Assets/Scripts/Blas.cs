using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blas : NPCInteraction
{
    public string preInteractionDialogue;
    public string postInteractionDialogue;
    public string idleDialogue;
    protected override void Start()
    {
        base.Start();
        orientation.Add("Idle");
        orientation.Add("WalkRight");
        orientation.Add("IdleRight");
    }
    void Update(){
        if (hasInteracted[1]||GameManager.instance.blasInteraction) {
            Speech(idleDialogue,3);
        } else if (hasInteracted[0]&&GameManager.instance.randyInteraction) {
            Speech(postInteractionDialogue,1);
            GameManager.instance.blasInteraction=hasInteracted[1];
            GetComponent<AudioSource>().Play();
        } else {
            Speech(preInteractionDialogue,0);
        }
    }
}
