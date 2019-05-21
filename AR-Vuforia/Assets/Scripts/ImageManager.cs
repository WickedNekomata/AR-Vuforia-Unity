using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : DefaultTrackableEventHandler
{
    public GameObject child = null;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        child.SetActive(true);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        child.SetActive(false);
    }
}