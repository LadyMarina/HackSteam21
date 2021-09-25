using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackStem
{
    [CreateAssetMenu(fileName = "MathTowersData", menuName = "Minigames/Maths/MathTowersData")]
    public class MathTowersData : ScriptableObject
    {
        [SerializeField] private List<MathTowersCombination> _mathTowersCombinations;

        public MathTowersCombination GetCombination(int id)
        {
            if (CheckID(id))
                return null;

            return _mathTowersCombinations[id];
        }

        public string GetGoodOperationBySlot(int slot, int id)
        {
            if (CheckID(id))
                return null;
            
            switch (slot)
            {
                case 0:
                {
                   return _mathTowersCombinations[id].GoodOperation1;
                }
                case 1:
                {
                    return _mathTowersCombinations[id].GoodOperation2;
                }
            }

            Debug.Log("Wrong slot");
            return null;
        }

        public bool CheckID(int id)
        {
            if (id >= _mathTowersCombinations.Count)
            {
                Debug.Log("Id not found.");
                return false;
            }

            return true;
        }
    }

    [Serializable]
    public class MathTowersCombination
    {
        public string GoodOperation1;
        public string GoodOperation2;

        public string[] WrongAnswers;
    }
}
