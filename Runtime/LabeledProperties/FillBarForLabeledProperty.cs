using HyperGnosys.Core;
using UnityEngine;
using UnityEngine.UI;

namespace HyperGnosys.uGUIElements
{
    [RequireComponent(typeof(Slider))]
    public class FillBarForLabeledProperty : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private ExternalizableLabeledProperty<float> propertyCurrentValue;
        [SerializeField] private ExternalizableLabeledProperty<float> propertyMaxValue;
        private void Reset()
        {
            slider = GetComponent<Slider>();
        }
        private void OnEnable()
        {
            slider.maxValue = propertyMaxValue.Value;
            slider.value = propertyCurrentValue.Value;

            propertyCurrentValue.AddListener(SynchronizeSliderValue);
            propertyMaxValue.AddListener(SynchronizeSliderMax);
        }
        private void SynchronizeSliderValue(float newValue)
        {
            slider.value = newValue;
        }
        private void SynchronizeSliderMax(float newValue)
        {
            slider.maxValue = newValue;
        }
        private void OnDisable()
        {
            propertyCurrentValue.RemoveListener(SynchronizeSliderValue);
            propertyMaxValue.RemoveListener(SynchronizeSliderMax);
        }
    }
}