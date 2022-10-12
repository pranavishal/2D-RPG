using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;
    public bool isRing;
    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;
    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr, affectDf;
    [Header("Weapon/Armor Details")]
    public int weaponStrength;
    public int armorStrength;


   




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use(int charToUseOn)
    {
        CharacterStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (isItem)
        {
            if (affectHP)
            {
                selectedChar.currentHP += amountToChange;

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }
            if (affectMP)
            {
                selectedChar.currentMP += amountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }

            if (affectStr)
            {
                selectedChar.strength += amountToChange;
            }


        }

        if (isWeapon)
        {
            if (selectedChar.equippedWpn != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWpn);

            }

            selectedChar.equippedWpn = itemName;
            selectedChar.wpnPwer = weaponStrength;
        }

        if (isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmr);
            }

            selectedChar.equippedArmr = itemName;
            selectedChar.armrPwr = armorStrength;
        }



        if (!isRing)
        {
            GameManager.instance.RemoveItem(itemName);
        }


    }

    public void BattleUse(string charToUseOn)
    {
        for (int i = 0; i < BattleManager.instance.activeBattlers.Count; i++)
        {
            if (charToUseOn == BattleManager.instance.activeBattlers[i].charName)
            {
                if (affectHP)
                {
                    BattleManager.instance.activeBattlers[i].currentHp += amountToChange;

                    if (BattleManager.instance.activeBattlers[i].currentHp > BattleManager.instance.activeBattlers[i].maxHP)
                    {
                        BattleManager.instance.activeBattlers[i].currentHp = BattleManager.instance.activeBattlers[i].maxHP;
                    }


                }

                if (affectMP)
                {
                    BattleManager.instance.activeBattlers[i].currentMP += amountToChange;

                    if (BattleManager.instance.activeBattlers[i].currentMP > BattleManager.instance.activeBattlers[i].maxMP)
                    {
                        BattleManager.instance.activeBattlers[i].currentMP = BattleManager.instance.activeBattlers[i].maxMP;
                    }
                }

                if (affectStr)
                {
                    BattleManager.instance.activeBattlers[i].strength += amountToChange;
                }

                if (affectDf)
                {
                    BattleManager.instance.activeBattlers[i].defence += amountToChange;
                }

                if (isWeapon)
                {
                    BattleManager.instance.EquipWeaponMidBattle();
                }

                if (isArmor)
                {
                    BattleManager.instance.EquipArmorMidBattle();
                }

                if (isRing)
                {
                    BattleManager.instance.UseRingMidBattle();
                }
            }
        }
        {

        }
    }

    
}
