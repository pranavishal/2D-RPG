using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //character name
    public string charName;
    //his level
    public int playerLevel = 1;
    //how much EXP
    public int currentEXP;
    //how much EXP to get to the next level
    public int[] expToNextLevel;
    //max level that can be achieved
    public int maxLevel = 100;
    //how much exp to surpass the base level
    public int baseExp = 1000;
    //how much hp
    public int currentHP;
    //maximum hp
    public int maxHP = 100;
    //current magic points
    public int currentMP;
    //maximum magic points
    public int maxMP = 30;
    //MP upgrades for a new level
    public int[] mpLvlBonus;
    //current strength stat
    public int strength;
    //current defence stat
    public int defence;
    //current weapon power
    public int wpnPwer;
    //current armour power
    public int armrPwr;
    //what weapon is equipped
    public string equippedWpn;
    //what armour is equipped
    public string equippedArmr;

    //what image is used
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        //set the exp to next level array size to the max level int
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1]* 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(1000);
        }
        
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {



            while (currentEXP >= expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                //determine whether add to strength or defencebased on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength += 3;

                    defence += 2;

                }
                else
                {
                    strength += 2;
                    defence += 3;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }
        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
