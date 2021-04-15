using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    private Camera mTheCamera;
    private Bounds mWorldBound;

    // Start is called before the first frame update
    void Start()
    {
        mTheCamera = gameObject.GetComponent<Camera>();
        mWorldBound = new Bounds();
        float maxX = mTheCamera.orthographicSize * mTheCamera.aspect, maxY = mTheCamera.orthographicSize;
        float sizex = maxX, sizey = maxY;
        Vector2 pos = mTheCamera.transform.position;
        mWorldBound.center = pos;
        mWorldBound.size = new Vector2(sizex, sizey);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Bounds GetWorldBound()
    {
        return mWorldBound;
    }

    public bool isInside(Bounds b1)
    {
        return isInsideBounds(b1, mWorldBound);
    }

    public bool isInsideBounds(Bounds b1, Bounds b2)
    {
        return (b1.min.x < b2.max.x) &&
               (b1.max.x > b2.min.x) &&
               (b1.min.y < b2.max.y) &&
               (b1.max.y > b2.min.y);
    }
}