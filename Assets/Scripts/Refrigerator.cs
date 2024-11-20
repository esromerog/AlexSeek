using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : NPCInteraction
{
    public string dialogue;
    protected override void Start()
    {
        base.Start();
        orientation.Add("IdleLeft");
        orientation.Add("WalkLeft");
        MusicManager.musicManagerInstance.FadeIn();
    }
    void Update(){
        if(!hasInteracted[0]) {
            Speech(dialogue,0);
        }
    }
}
