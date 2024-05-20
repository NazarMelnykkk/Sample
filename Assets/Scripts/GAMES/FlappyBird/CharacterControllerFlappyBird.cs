using UnityEngine;

namespace FlappyBird
{
    public class CharacterControllerFlappyBird : MonoBehaviour
    {
        [Header("Physics")]
        private float _gravity = -9.8f;
        private float strenght = 5f;

        private Vector3 _direction;


        public void Jump()
        {
            _direction = Vector3.up * strenght;
        }

        private void FixedUpdate()
        {
            _direction.y += _gravity * Time.deltaTime;
            transform.position += _direction * Time.deltaTime;
        }
    }
}
