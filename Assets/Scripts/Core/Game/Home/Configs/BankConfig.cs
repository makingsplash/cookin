using System;
using System.Collections.Generic;
using Core.Consumables;
using UnityEngine;

namespace Core.Game.Home.Configs
{
    public class BankConfig : ScriptableObject
    {
        public List<BankConfigItem> BankItems;
    }

    // temp
    [Serializable]
    public class BankConfigItem
    {
        public ConsumableType ProductConsumableType;
        public int ProductAmount;

        public bool Free;
        public ConsumableType PriceConsumableType;
        public int PriceAmount;
    }
}