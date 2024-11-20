using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : NPCInteraction
{
    public string dialogue;
    protected override void Start()
    {
        base.Start();
        orientation.Add("IdleBack");
        orientation.Add("WalkBack");
    }
    void Update(){
        if(!hasInteracted[0]) {
            Speech(dialogue,0);
        }
    }
}
