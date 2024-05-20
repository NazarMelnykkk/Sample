using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour, IMovable
    {
        [SerializeField] private float _speed = 0.8f;

        private float _disablePos = -13f;

        private Coroutine _moveCoroutine;

        private void OnEnable()
        {
            if (_moveCoroutine == null)
            {
                _moveCoroutine = StartCoroutine(MoveCoroutine());
            }
        }

        private void OnDisable()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }
        }

        public void Move()
        {
            transform.position += Vector3.left * _speed * Time.fixedDeltaTime;

            if (transform.position.x < _disablePos)
            {
                gameObject.SetActive(false);
            }
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Time.fixedDeltaTime);
                Move();
            }
        }
    }
}
