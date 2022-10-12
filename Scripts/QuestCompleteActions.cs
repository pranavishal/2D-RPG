using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuestCompleteActions : MonoBehaviour
{
    public string Amelia, Elder, Nephew, Fire, Magic, Trollie;
    public GeneralNotification notification;
    public static QuestCompleteActions instance;



    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PostQuestActions(string questToMark)
    {
        string markQuest = questToMark;
        Debug.Log(questToMark);
        if (markQuest == Amelia)
        {
            notification.notificationImage.sprite = notification.notificationSprites[0];
            notification.theText.text = "Amelia Gave a Wooden Sword!";
            notification.Activate();

            GameManager.instance.AddItem("Wooden Sword");
            
        }
        if (markQuest == Elder)
        {
            notification.notificationImage.sprite = notification.notificationSprites[1];
            notification.theText.text = "The Elder Gave Some Health Potions!";
            notification.Activate();

            
            
            for (int i = 0; i < 5; i++)
            {
                GameManager.instance.AddItem("Health Potion");
                

            }



        }

        if (questToMark == Nephew)
        {
            StartCoroutine(FadeFromSceneCo());
           
        }

        if(questToMark == Fire)
        {
            
            for(int i = 0; i < BattleManager.instance.playerPrefabs.Length; i++)
            {
                if (BattleManager.instance.playerPrefabs[i].charName == "Dexter")
                {
                    string[] newMovesAvailable = new string[1];
                    newMovesAvailable[0] = "Fire";
                    BattleManager.instance.playerPrefabs[i].movesAvailable = newMovesAvailable;
                }
            }
        }

        if (questToMark == Magic) 
        {
            StartCoroutine(GeneralFadeFromSceneCo("OdaluHome", new Vector3(0f, 0f, 0f)));
        }

        if(questToMark == Trollie)
        {
            for(int i = 0; i < GameManager.instance.playerStats.Length; i++)
            {
                if(GameManager.instance.playerStats[i].charName == "Trollie")
                {
                    GameManager.instance.playerStats[i].gameObject.SetActive(true);
                }
            }

            for (int i = 0; i < BattleManager.instance.playerPrefabs.Length; i++)
            {
                if (BattleManager.instance.playerPrefabs[i].charName == "Dexter")
                {
                    string[] newMovesAvailable = new string[2];
                    newMovesAvailable[0] = "Fire";
                    newMovesAvailable[1] = "Ice";
                    BattleManager.instance.playerPrefabs[i].movesAvailable = newMovesAvailable;
                }
            }

            notification.notificationImage.sprite = notification.notificationSprites[3];
            notification.theText.text = "Trollie has decided to join you! Trollie lent his Ice manipulation ability!";
            notification.Activate();

            StartCoroutine(GeneralFadeFromSceneCo("Graveyard", new Vector3(-5.417429f, -25.0346f, 0f)));
        }

        

       
            
    }

    public IEnumerator FadeFromSceneCo()
    {
        
        UIFade.instance.FadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ElderElort");
        PlayerController.instance.transform.position = new Vector3(0.0109598f, 2.042522f, -1.041406f);
        UIFade.instance.FadeFromBlack();
        yield return new WaitForSeconds(1.5f);
    }

    public IEnumerator GeneralFadeFromSceneCo(string sceneToLoad, Vector3 location)
    {
        UIFade.instance.FadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
        PlayerController.instance.transform.position = location;
        UIFade.instance.FadeFromBlack();
        yield return new WaitForSeconds(1f);
    }

   
            
        
    

}
