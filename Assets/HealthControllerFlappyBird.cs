using UnityEngine;

namespace FlappyBird
{
    public class HealthControllerFlappyBird : MonoBehaviour
    {
        [SerializeField] private string _triggerToGameOver = "Default";

        [SerializeField] private GameControllerFlappyBird _gameController;

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.layer == LayerMask.NameToLayer(_triggerToGameOver))
            {
                _gameController.GameOver();
            }
        }
    }
}