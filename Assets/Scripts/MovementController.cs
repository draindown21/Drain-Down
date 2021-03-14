using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


namespace MovementController
{
    public class MovementController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] GameObject targetObject;

        [SerializeField] float speed = 5f;

        [SerializeField] ButtonLabel butttonLabel;

        bool buttonDown = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            buttonDown = true;

            if (eventData.selectedObject.gameObject.transform.GetComponent<MovementController>().butttonLabel.Equals(ButtonLabel.LEFT_BUTTON))
            {
                MoveLeft();
            }

            else if (eventData.selectedObject.gameObject.transform.GetComponent<MovementController>().butttonLabel.Equals(ButtonLabel.RIGHT_BUTTON))
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