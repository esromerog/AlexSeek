using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip startMusic;
    public AudioClip generalMusic;
    public AudioSource audio;
    AudioSource[] audioSources;
    public static MusicManager musicManagerInstance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAudio());
        Scene currentScene=SceneManager.GetActiveScene();
        if (currentScene.name=="Floor2"||currentScene.name=="Main") {
            DontDestroyOnLoad(this);
            if (musicManagerInstance==null){
                musicManagerInstance=this;
            } else {
                Destroy(gameObject);
            }
        }
        audioSources=GetComponents<AudioSource>();
        audio=audioSources[0];
        startMusic=audioSources[1].clip;
        generalMusic=audioSources[2].clip;
    }
    public void FadeOut(){
        StartCoroutine(FadeAudioSource.StartFade(audioSources[1],2f,0f));
    }

    public void FadeIn(){
        StartCoroutine(FadeAudioSource.StartFade(audioSources[1],2f,0.5f));
    }
    public IEnumerator playAudio(){
        audio.PlayOneShot(startMusic);
        yield return new WaitForSecondsRealtime(startMusic.length);
        audio.PlayOneShot(generalMusic);
    }
    
}
