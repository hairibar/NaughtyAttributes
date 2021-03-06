﻿using UnityEngine;

namespace NaughtyAttributes.Test
{
    public class UsePropertySetterTest : MonoBehaviour
    {
        public bool TestBool
        {
            get => _testBool;
            set
            {
                Debug.Log(value);
                _testBool = value;
            }
        }
        [SerializeField, UsePropertySetter] private bool _testBool;

        public string TestString
        {
            get => _testString;
            set
            {
                print($"Previous: {_testString}, New: {value}");
                _testString = value;
            }
        }
        [SerializeField, UsePropertySetter, Delayed]
        private string _testString;

        public float MyPositiveProperty
        {
            get => _myPositiveProperty;
            set
            {
                if (value >= 0)
                {
                    _myPositiveProperty = value;
                    OnNewValue?.Invoke(value);
                }
                else Debug.Log("Negative! Not setting that.");
            }
        }
        [SerializeField, UsePropertySetter("MyPositiveProperty"), Tooltip("This is a working tooltip."),]
        private float _myPositiveProperty;


        public event System.Action<float> OnNewValue;

        private void OnEnable()
        {
            OnNewValue -= PrintValue;
            OnNewValue += PrintValue;
        }

        private void PrintValue(float a)
        {
            print($"New value: {a}!");
        }
    }
}