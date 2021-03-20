using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Combat
{
    [System.Serializable]
    public enum Label { NONE, ATTACK_BUTTON, SPECIAL_ATTACK_BUTTON }


    public class AttackController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public delegate void OnAttack();
        public event OnAttack AttackStarted;
        public event OnAttack AttackEnded;

        [SerializeField] Label label;
        
        public void OnPointerDown(PointerEventData eventData)
        {

            Label currentObjectLabel = eventData.pointerCurrentRaycast.gameObject.transform.GetComponent<AttackController>().label;
            if (currentObjectLabel.Equals(Label.ATTACK_BUTTON))
            {
                AttackStarted?.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            AttackEnded?.Invoke();
        }
    }
}
