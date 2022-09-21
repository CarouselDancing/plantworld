using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightMoodHandler : MonoBehaviour
{

    public GameObject[] lightMoods;
    private int moodCounter;

    public Text displayText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // --- Skip light to next mood ---
    public void NextMood()
    {
        if(moodCounter < lightMoods.Length-1){
            moodCounter++;
            ChangeMood(moodCounter);
        }
        else{
            moodCounter=0;
            ChangeMood(moodCounter);
        }

         StartCoroutine(UILight());
    }

    // --- Previous light mood ---
    public void PreviousMood()
    {
        if(moodCounter > 0){
            moodCounter--;
            ChangeMood(moodCounter);
        }
        else{
            moodCounter=lightMoods.Length-1;
            ChangeMood(moodCounter);
        }
        StartCoroutine(UILight());
    }
    // --- Disable all light moods and only enable next/prev ---
    public void ChangeMood(int counter){
        for(int i = 0; i< lightMoods.Length; i++){
            lightMoods[i].SetActive(false);
        }
        lightMoods[moodCounter].SetActive(true);
    }

    IEnumerator UILight()
    {

        string temp = displayText.text;
        displayText.text = "Lightmood changed";
        yield return new WaitForSecondsRealtime(2);
        displayText.text = temp;
    }
    
   
}
