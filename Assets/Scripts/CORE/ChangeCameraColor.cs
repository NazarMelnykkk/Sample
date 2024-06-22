using UnityEngine;

public class ChangeCameraColor : MonoBehaviour
{
    [SerializeField] private Color _color;

    private void Start()
    {
        Camera.main.backgroundColor = _color;
    }

}
