using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkRoom : MonoBehaviour
{
    BoxCollider2D boxCollider;
    BoxCollider2D playerCollider;
    BoxCollider2D mirrorCollider;
    public GameObject cover;
    GameObject hero;

    void Start() {
        MusicManager.musicManagerInstance.FadeOut();
        boxCollider=GetComponent<BoxCollider2D>();
        hero = GameObject.Find("hero");
        playerCollider = hero.GetComponent<BoxCollider2D>();
        cover.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    void Update() {
        OnCollide();
    }

    protected virtual void OnCollide() {
        bool facingNPC=hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("WalkBack");
        if (boxCollider.bounds.Intersects(playerCollider.bounds)) {
            Debug.Log("Entered Collision");
            cover.SetActive(false);
            StartCoroutine(Waiter());
            DontDestroyOnLoad(this);
        }
    }
    IEnumerator Waiter(){
        Time.timeScale=0;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale=1;
        SceneManager.LoadScene("Ending");
    }
}
