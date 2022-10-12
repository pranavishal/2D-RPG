using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemMenu : MonoBehaviour
{

    public GameObject battleItems;
    public ItemButton[] battleItemButtons;
    public string selectedItem;
    public Item activeItem;
    public Text itemName, itemDescription, useButtonText;

    public GameObject itemCharChoiceMenu;
    public Text[] itemCharChoiceNames;

    public static BattleItemMenu instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenItemMenu()
    {
        battleItemButtons[0].Press();
        battleItems.SetActive(true);

        GameManager.instance.SortItems();
        for (int i = 0; i < battleItemButtons.Length; i++)
        {
            battleItemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                battleItemButtons[i].buttonImage.gameObject.SetActive(true);
                battleItemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                battleItemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }

            else
            {
                battleItemButtons[i].buttonImage.gameObject.SetActive(false);
                battleItemButtons[i].amountText.text = "";
            }
        }
        
    }

    public void CloseItemMenu()
    {
        if (!itemCharChoiceMenu.gameObject.activeInHierarchy)
        {

            battleItems.SetActive(false);
        }
        if (itemCharChoiceMenu.gameObject.activeInHierarchy)
        {
            itemCharChoiceMenu.SetActive(false);
        }
        
       
       
    }

    public void SelectItem(Item newItem)
    {
        activeItem = newItem;

        if (activeItem.isItem || activeItem.isRing)
        {
            useButtonText.text = "Use";
        }
        if(activeItem.isWeapon || activeItem.isArmor)
        {
            useButtonText.text = "Equip";
        }


        itemName.text = activeItem.itemName;
        itemDescription.text = activeItem.description;
    }

    public void OpenItemCharChoice()
    {
        itemCharChoiceMenu.SetActive(true);

        itemCharChoiceMenu.SetActive(true);

        for (int i = 0; i < itemCharChoiceNames.Length; i++)
        {
            itemCharChoiceNames[i].text = GameManager.instance.playerStats[i].charName;
            itemCharChoiceNames[i].transform.parent.gameObject.SetActive(GameManager.instance.playerStats[i].gameObject.activeInHierarchy);
        }
    }

    public void CloseItemCharChoice()
    {
        itemCharChoiceMenu.SetActive(false);
    }

    public void UseItem(string charName)
    {
        activeItem.BattleUse(charName);
        BattleManager.instance.UpdateUIStats();

        if (activeItem.isItem)
        {
            DiscardItem();
            BattleManager.instance.NextTurn();
        }
        
        Debug.Log("Did it");
        OpenItemMenu();
        CloseItemCharChoice();
        CloseItemMenu();
    }
    public void DiscardItem()
    {
        if (activeItem.isRing)
        {
            BattleManager.instance.DiscardRingMidBattle();
        }
        if (activeItem != null && !activeItem.isRing)
        {
            GameManager.instance.RemoveItem(activeItem.itemName);
        }
    }
}
