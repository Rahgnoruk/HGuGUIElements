using HyperGnosys.Core;
using TMPro;
using UnityEngine;

namespace HyperGnosys.uGUIElements
{
    [RequireComponent(typeof(TMP_Text))]
    public class LabelTextForLabeledProperty : MonoBehaviour
    {
        [SerializeField] private TMP_Text labelText;
        [SerializeField] private ExternalizableLabeledProperty<float> property;
        private void Reset()
        {
            labelText = GetComponent<TMP_Text>();
        }
        private void OnEnable()
        {
            labelText.text = property.Label;
        }
    }
}