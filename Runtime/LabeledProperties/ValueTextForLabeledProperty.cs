using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HyperGnosys.uGUIElements
{
    [RequireComponent(typeof(TMP_Text))]
    public class ValueTextForLabeledProperty : MonoBehaviour
    {
        [SerializeField] private TMP_Text labelText;
        [SerializeField] private ExternalizableLabeledProperty<float> property;
        private void Reset()
        {
            labelText = GetComponent<TMP_Text>();
        }
        private void OnEnable()
        {
            labelText.text = property.Value.ToString("F1");

            property.AddListener(SynchronizeSliderValue);
        }
        private void SynchronizeSliderValue(float newValue)
        {
            labelText.text = newValue.ToString("F1");
        }
        private void OnDisable()
        {
            property.RemoveListener(SynchronizeSliderValue);
        }
    }
}