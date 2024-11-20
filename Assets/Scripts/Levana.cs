using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levana : NPCInteraction {
    public string preInteractionDialogue;
    public string postInteractionDialogue;
    public string idleDialogue;
    private GameObject fridge;
    protected override void Start()
    {
        base.Start();
        orientation.Add("IdleBack");
        orientation.Add("WalkBack");
        fridge=GameObject.Find("Refrigerator");
    }
    void Update(){
        if (hasInteracted[1]||GameManager.instance.levanaInteraction) {
            Speech(idleDialogue,3);
        } else if (hasInteracted[0]&&fridge.GetComponent<Refrigerator>().hasInteracted[0]) {
            Speech(postInteractionDialogue,1);
            GameManager.instance.levanaInteraction=hasInteracted[1];
        } else {
            Speech(preInteractionDialogue,0);
        }
    }
}
