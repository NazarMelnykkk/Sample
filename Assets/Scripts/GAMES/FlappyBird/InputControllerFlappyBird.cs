using UnityEngine;

namespace FlappyBird
{
    public class InputControllerFlappyBird : MonoBehaviour
    {
        [SerializeField]
        private CharacterControllerFlappyBird _characterController;

        private void OnEnable()
        {
            SystemLinkHolder.Instance.InputController.OnJumpPerformedEvent += Jump;
        }

        private void OnDisable()
        {
            SystemLinkHolder.Instance.InputController.OnJumpPerformedEvent -= Jump;
        }

        private void Jump()
        {
            _characterController.Jump();
        }

    }
}

