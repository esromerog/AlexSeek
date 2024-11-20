using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject logo;
    public GameObject credits;
    public GameObject postCredits;

    void Start()
    {
        logo.SetActive(false);
        credits.SetActive(false);
        postCredits.SetActive(false);
        StartCoroutine(Waiter()); 
    }

    IEnumerator Waiter(){
        logo.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        logo.SetActive(false);
        credits.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        credits.SetActive(false);
        postCredits.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        Application.OpenURL("https://instagram.com/seek_game?utm_medium=copy_link");
    }
}
