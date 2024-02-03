using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GigaButton : MonoBehaviour
{
    public abstract void Click();
    public abstract void Hover(bool highlight);
}
