using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Movement
{

    [System.Serializable]
    public enum ButtonLabel { LEFT_BUTTON, RIGHT_BUTTON }


    public class Mover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] GameObject targetObject;

        [SerializeField] float speed = 5f;

        [SerializeField] ButtonLabel butttonLabel;

        bool buttonDown = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            buttonDown = true;
            ButtonLabel label = eventData.selectedObject.gameObject.transform.GetComponent<Mover>().butttonLabel;

            if (label.Equals(ButtonLabel.LEFT_BUTTON))
            {
                MoveLeft();
            }

            else if (label.Equals(ButtonLabel.RIGHT_BUTTON))
            {
                MoveRight();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            buttonDown = false;
        }

        public void MoveLeft()
        {
            StartCoroutine(enumerator());
            IEnumerator enumerator()
            {
                while (buttonDown)
                {
                    targetObject.transform.position = new Vector2(targetObject.transform.position.x - speed * Time.deltaTime, targetObject.transform.position.y);
                    yield return null;
                }
            }
        }

        public void MoveRight()
        {
            StartCoroutine(enumerator());
            IEnumerator enumerator()
            {
                while (buttonDown)
                {
                    targetObject.transform.position = new Vector2(targetObject.transform.position.x + speed * Time.deltaTime, targetObject.transform.position.y);
                    yield return null;
                }
            }
        }
    }
}