using UnityEngine;

/// <summary>
/// use for containers of objects on canvas
/// </summary>
public class UIContainerController : MonoBehaviour, IUIContainerable
{
    [SerializeField] private GameObject _container;

    public void Activate()
    {
        _container.SetActive(!_container.activeInHierarchy);
    }
}
