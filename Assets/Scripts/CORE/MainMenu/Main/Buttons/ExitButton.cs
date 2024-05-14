using UnityEngine;
public class ExitButton : ButtonClickedBase
{
    public override void Click()
    {
        base.Click();

        Application.Quit();
    }
}
