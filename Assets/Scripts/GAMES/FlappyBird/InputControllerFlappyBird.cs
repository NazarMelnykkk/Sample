using UnityEngine;

namespace FlappyBird
{
    public class InputControllerFlappyBird : MonoBehaviour
    {
        [SerializeField]
        private CharacterControllerFlappyBird _characterController;

        private void OnEnable()
        {
            InputController.Instance.OnJumpPerformedEvent += Jump;
        }

        private void OnDisable()
        {
            InputController.Instance.OnJumpPerformedEvent -= Jump;
        }

        private void Jump()
        {
            _characterController.Jump();
        }

    }
}

