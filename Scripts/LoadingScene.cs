using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    public float waitToLoad;
    public bool isNewGame;

    
    public string entryScene;

    // Start is called before the first frame update
    void Start()
    {
        isNewGame = MainMenu.instance.isNewGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToLoad > 0)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0)
            {
                if (!isNewGame)
                {
                    Debug.Log(isNewGame);

                    SceneManager.LoadScene(PlayerPrefs.GetString("Current_Scene"));

                    GameManager.instance.LoadData();
                    QuestManager.instance.LoadQuestData();
                }
                else
                {
                    Debug.Log(isNewGame);
                    SceneManager.LoadScene(entryScene);
                }
            }
                
        }
        
    }
}
