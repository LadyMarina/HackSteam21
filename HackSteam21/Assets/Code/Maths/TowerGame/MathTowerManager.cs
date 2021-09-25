using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace HackStem
{
    public class MathTowerManager : MonoBehaviour
    {
        [SerializeField] private MathTowersData _mathTowersData;
        [SerializeField] private NumberBlock[] _numberBlocks;

        private int _totalCombinations;
        private List<int> _alreadySearchedNumbers;

        [SerializeField] private Color _wrongColor;
        [SerializeField] private Color _goodColor;
        [SerializeField] private Image _equalImage;

        [SerializeField] private NumberBlockSlot slot1;
        [SerializeField] private NumberBlockSlot slot2;

        [SerializeField] private GameObject _spawnBlock;
        [SerializeField] private Transform _spawnTransform;
        private Vector2[] _blocksStartingPosition;
        
        
        private void Awake()
        {
            _alreadySearchedNumbers = new List<int>();
            _totalCombinations = _mathTowersData.GetNumberOfCombinations();

            _blocksStartingPosition = new Vector2[_numberBlocks.Length];
            SetStartingBlocksPosition();
        }

        private void Start()
        {
            SetUpNewRound();
        }

        private void Update()
        {
            if (slot1.Filled && slot2.Filled)
            {
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(RightOrWrong(true));
                }
                else
                {
                    StartCoroutine(RightOrWrong(false));
                }
                    
                slot1.Filled = false;
                slot2.Filled = false;
            }
        }

        IEnumerator RightOrWrong(bool correct)
        {
            if (correct)
            {
                DropBlock();
                _equalImage.color = _goodColor;
            }
            else
            {
                _equalImage.color = _wrongColor;
            }

            yield return new WaitForSeconds(2);

            _equalImage.color = Color.white;
            SetUpNewRound();
        }

        private void DropBlock()
        {
            Instantiate(_spawnBlock, _spawnTransform.position, Quaternion.identity, _spawnTransform);
        }

        private void SetStartingBlocksPosition()
        {
            for (int i = 0; i < _numberBlocks.Length; ++i)
            {
                _blocksStartingPosition[i] = _numberBlocks[i].transform.localPosition;
            }
        }
        private void ResetBlockPositions()
        {
            for (int i = 0; i < _numberBlocks.Length; ++i)
            {
                _numberBlocks[i].transform.localPosition = _blocksStartingPosition[i];
            }
        }
        
        private void SetUpNewRound()
        {
            
            ClearAllBlocks();
            _alreadySearchedNumbers.Clear();
            ResetBlockPositions();

            int randomID = GetRandomNumber();
            MathTowersCombination mathTowersCombination = _mathTowersData.GetCombination(randomID);

            List<string> combinations = new List<string>();
            foreach (string answer in mathTowersCombination.WrongAnswers)
            {
                combinations.Add(answer);
            }
            combinations.Add(mathTowersCombination.GoodOperation1);
            combinations.Add(mathTowersCombination.GoodOperation2);
            
            for (int i = 0; i < combinations.Count; ++i)
            {
                NumberBlock block = GetRandomBlock();
                block.SetOperation(combinations[i]);
            }
        }

        private NumberBlock GetRandomBlock()
        {
            int randomNumber = Random.Range(0, _numberBlocks.Length);
            NumberBlock block = _numberBlocks[randomNumber];
            
            while (block.GetOperation() != String.Empty)
            {
                randomNumber = Random.Range(0, _numberBlocks.Length);
                block = _numberBlocks[randomNumber];
            }
            
            return block;
        }

        private int GetRandomNumber()
        {
            int randomNumber = Random.Range(0, _totalCombinations);
            
            while (_alreadySearchedNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, _totalCombinations);
            }
            
            _alreadySearchedNumbers.Add(randomNumber);

            return randomNumber;
        }

        private void ClearAllBlocks()
        {
            foreach (var block in _numberBlocks)
            {
                block.SetOperation(String.Empty);
            }
        }
    }
}
