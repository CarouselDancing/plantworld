using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{

    public AudioClip[] songs;
    private int songCounter;
    public GameObject[] m_MusicSources;

    public Text displayText;

    // --- Default: Play Music on Start ---
    void Start()
    {
        // Set random track to play at the beginning
        //songCounter=Random.Range(0,songs.Length);
        songCounter=0;
        // List of all GameObjects with Tag "Music" - Always tag "Music" in the Audio Sources to be included!
        m_MusicSources = GameObject.FindGameObjectsWithTag("Music");
        if (m_MusicSources.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'Music'");
        }

        // Default: Play ranodm song on Start with 5s Delay
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().clip = songs[songCounter];
            //audioSource.GetComponent<AudioSource>().PlayDelayed(5f);
        }

        displayText.text = songs[songCounter].name;
    }


    // --- Handler to Start Music ---
    public void StartMusic()
    {
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().Play();
            audioSource.GetComponentInChildren<ParticleSystem>().Play();
        }
        
    }

    public void Update (){
        
        if(Input.GetKey("space")){
            StartMusic();
        }
        if(Input.GetKey("p")){
            PauseMusic();
        }
    }

    // --- Handler to Pause Music ---
    public void PauseMusic()
    {
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().Pause();
            audioSource.GetComponentInChildren<ParticleSystem>().Pause();
        }
        
    }
    // --- Increase Volume by 1/10 ---
    public void VolumeUp(){
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().volume+=0.1f;
        }
        StartCoroutine(UIVolUp());
    }

    // --- Decrease Volume by 1/10 ---
    public void VolumeDown(){
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().volume-=0.1f;
        }
        StartCoroutine(UIVolDown());
    }

    // --- Skip song to next one ---
    public void NextSong()
    {
        PauseMusic();
        AddToCount();
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().clip = songs[songCounter];
        }
        StartMusic();
        displayText.text = songs[songCounter].name;
    }

    // --- Previous Song ---
    public void PreviousSong()
    {
        PauseMusic();
        SubFromCount();
        foreach (GameObject audioSource in m_MusicSources)
        {
            audioSource.GetComponent<AudioSource>().clip = songs[songCounter];
        }
        StartMusic();
    }
    
    // --- Increment songCounter & loop List ---
    private void AddToCount(){
        if(songCounter < songs.Length-1){
            songCounter++;
        }
        else{
            songCounter=0;
        }
        
    }
    // --- Decrement songCounter & loop list ---
    private void SubFromCount(){
        if(songCounter > 0){
            songCounter--;
        }
        else{
            songCounter=songs.Length-1;
        }
        
    }


    IEnumerator UIVolUp()
    {
        displayText.text = "Volume increased";
        yield return new WaitForSecondsRealtime(2);
        displayText.text = songs[songCounter].name;
    }

    IEnumerator UIVolDown()
    {
        displayText.text = "Volume decreased";
        yield return new WaitForSecondsRealtime(2);
        displayText.text = songs[songCounter].name;
    }

    
    
}
