using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// highlighting an object on hover
/// </summary>
public class IconHoverHighlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color hoverColor = Color.gray; 

    private Image iconImage;
    private Color originalColor;

    private void Awake()
    {
        iconImage = GetComponent<Image>();
        originalColor = iconImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        iconImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        iconImage.color = originalColor;
    }

    public void OnEnable()
    {
        iconImage.color = originalColor;
    }
}
