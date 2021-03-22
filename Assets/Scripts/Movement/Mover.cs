using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Movement
{
    public class Mover : MonoBehaviour
    {
        Rigidbody2D myRigidbody;

        [SerializeField] float speed = 5f;
        [SerializeField] float jumpForce = 600f;

        bool isButtonDown = false;

        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

        public void MoveLeft(bool isButtonDown)
        {
            if (!isButtonDown) 
            { 
                StopAllCoroutines(); 
                return; 
            }

            StartCoroutine(enumerator());
            IEnumerator enumerator()
            {
                while (isButtonDown)
                {
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                    yield return null;
                }
            }
        }

        public void MoveRight(bool isButtonDown)
        {
            if (!isButtonDown)
            {
                StopAllCoroutines();
                return;
            }

            StartCoroutine(enumerator());
            IEnumerator enumerator()
            {
                while (isButtonDown)
                {
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                    yield return null;
                }
            }
        }

        public void Jump()
        {
            myRigidbody.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}