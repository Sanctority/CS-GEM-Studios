﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemChecker : MonoBehaviour {

    public int _coinsCost;

    [SerializeField]
    private int _itemID;

    [SerializeField]
    private TextMeshProUGUI _txtBuyItem;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {

        if (PlayerPrefs.GetInt(_itemID.ToString()) == 1)
        {

            if(PlayerPrefs.GetInt("Equipped") == _itemID)
            {
                _txtBuyItem.text = "Equipped";
            }
            else
            {
                _txtBuyItem.text = "Equip";
            }
            
        }
        else
        {
            _txtBuyItem.text = "Coins: " + _coinsCost.ToString();
        }
    }
}
