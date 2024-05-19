using UnityEngine;

public class —hange—amera—olor : MonoBehaviour
{
    [SerializeField] private Color _color;

    private void Start()
    {
        Camera.main.backgroundColor = _color;
    }

}
