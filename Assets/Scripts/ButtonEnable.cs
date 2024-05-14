using UnityEngine;

public class ButtonEnable : ButtonClickedBase
{
    [SerializeField] private UIContainerController _container;
    public override void Click()
    {
        base.Click();

        _container.Activate();
    }
}
