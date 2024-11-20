using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    private bool active=true;
    private Text txt;
    private float duration;
    public float speed=0.01f;
    private float lastShown;

    private int shownLines;
    private int totalLines;

    private GameObject hero;

    private void Start() {
        txt=textPrefab.GetComponent<Text>();
        hero = GameObject.Find("hero");
    }

    private void Update(){
        if (!active) {
            return;
        }
        if (shownLines>=totalLines) {
            Debug.Log("Ocultar texto...");
            Hide();
        }
    }

    public bool Show(string msg,int line) {
        string[] lines=msg.Split('|');
        shownLines=line;
        totalLines=lines.Length;
        if (shownLines<totalLines){
            ShowActivate(); 
            StartCoroutine(WriteText(lines[shownLines])); 
            return false;
        } else {
            Hide();
            hero.GetComponent<Player>().interacting=false;
            return true;
        }
        
    }

    public void ShowActivate() {
        active=true;
        lastShown=Time.time;
        textContainer.SetActive(active);
    }

    public void Hide() {
        active=false;
        textContainer.SetActive(active);
    }

    public IEnumerator WriteText(string words) {
        StringBuilder builder=new StringBuilder();
        foreach(char c in words) {
            builder.Append(c);
            txt.text=builder.ToString();
            yield return new WaitForSecondsRealtime(speed);
        }
    }

}
