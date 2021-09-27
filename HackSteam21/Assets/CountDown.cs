using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HackStem
{
    public class CountDown : MonoBehaviour
    {
        private Text _text;
        [SerializeField] private float _startTimer = 120f;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _startTimer -= Time.deltaTime;
            _text.text = Mathf.Round(_startTimer).ToString();
        }
    }
}
