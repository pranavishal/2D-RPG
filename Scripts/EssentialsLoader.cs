using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject theGameManager;
    public GameObject theAudioManager;
    public GameObject theBattleManager;
   
    // Start is called before the first frame update
    void Start()
    {
        if (UIFade.instance == null)
        {
           UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }
        if (PlayerController.instance == null)
        {
           PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;

        }
        if(GameManager.instance == null)
        {
            Instantiate(theGameManager);
        }
        if(AudioManager.instance == null)
        {
            Instantiate(theAudioManager);
        }

        if(BattleManager.instance == null)
        {
            Instantiate(theBattleManager);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
