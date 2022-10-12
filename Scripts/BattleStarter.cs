﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    public BattleType[] potentialBattles;

    public bool activateOnEnter, activateOnStay, activateOnExit;
    public float timeBetweenBattles = 10f;
    private float betweenBattleCounter;

    public bool deactivateAfterStarting;

    public bool cannotFlee;

    public bool shouldCompleteQuest;
    public string questToComplete;

    private bool inArea;
    // Start is called before the first frame update
    void Start()
    {
        betweenBattleCounter = Random.Range(timeBetweenBattles * .6f, timeBetweenBattles * 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(inArea && PlayerController.instance.canMove)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                betweenBattleCounter -= Time.deltaTime;
            }

            if(betweenBattleCounter <= 0)
            {
                betweenBattleCounter = Random.Range(timeBetweenBattles * 0.6f, timeBetweenBattles * 2f);
                StartCoroutine(StartBattleCo());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activateOnEnter)
            {
                StartCoroutine(StartBattleCo());
                inArea = true;
            }
            else
            {
                inArea = true;
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (activateOnExit)
            {
                StartCoroutine(StartBattleCo());
                Debug.Log("activateOnExit is true");
            }
            else
            {
                Debug.Log("Reached");
                inArea = false;
            }
            
        }
    }

    public IEnumerator StartBattleCo()
    {
        UIFade.instance.FadeToBlack();
        GameManager.instance.battleActive = true;

        int selectedBattle = Random.Range(0, potentialBattles.Length);
        Debug.Log(potentialBattles.Length);
        Debug.Log(selectedBattle);

        BattleManager.instance.rewardItems = potentialBattles[selectedBattle].rewardItems;
        BattleManager.instance.rewardXP = potentialBattles[selectedBattle].rewardXP;

        yield return new WaitForSeconds(2f);
        UIFade.instance.FadeFromBlack();

        BattleManager.instance.BattleStart(potentialBattles[selectedBattle].enemies, cannotFlee);

        if (deactivateAfterStarting)
        {
            gameObject.SetActive(false);
        }

        BattleReward.instance.markQuestComplete = shouldCompleteQuest;
        BattleReward.instance.questToMark = questToComplete;

    }
}
