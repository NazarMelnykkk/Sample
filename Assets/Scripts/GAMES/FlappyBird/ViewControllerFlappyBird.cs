using System.Collections;
using UnityEngine;
namespace FlappyBird
{
    public class ViewControllerFlappyBird : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        private SpriteRenderer _sprite;
        private int _spriteIndex = 0;

        private float _updateTime = 0.15f;
        private Coroutine _animCoroutine;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();

            StartCoroutine(AnimateSpriteCoroutine());
        }

        private void Start()
        {
            StartAnimation();
        }

        public void StartAnimation()
        {
            if (_animCoroutine == null)
            {
                _animCoroutine = StartCoroutine(AnimateSpriteCoroutine());
            }
        }

        public void StopAnimation()
        {
            if (_animCoroutine != null)
            {
                StopCoroutine(_animCoroutine);
                _animCoroutine = null;
            }
        }

        private IEnumerator AnimateSpriteCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_updateTime);

                _spriteIndex++;

                if (_spriteIndex >= _sprites.Length)
                {
                    _spriteIndex = 0;
                }

                _sprite.sprite = _sprites[_spriteIndex];
            }
        }
    }
}

   
