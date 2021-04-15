using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public Text mEnemyCountText = null, mEggCountText = null, mModeText = null;
    public float speed = 20f, mHeroRotateSpeed = 90f / 2f;
    public bool mFollowMousePosition = true;

    private int mPlanesTouched = 0, mEggCount = 0;

    private GameController mGameController = null;

    // Start is called before the first frame update
    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.M))
        {
            mFollowMousePosition = !mFollowMousePosition;
            if (mFollowMousePosition)
                mModeText.text = "Mode: Mouse";
            else
                mModeText.text = "Mode: WASD";
        }

        if (mFollowMousePosition)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                pos += ((speed * Time.smoothDeltaTime) * transform.up);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                pos -= ((speed * Time.smoothDeltaTime) * transform.up);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject egg = Instantiate(Resources.Load("Egg") as GameObject);
            ++mEggCount;
            mEggCountText.text = "Egg Count = " + mEggCount;
            egg.transform.localPosition = transform.localPosition;
            egg.transform.rotation = transform.rotation;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            mPlanesTouched++;
            mEnemyCountText.text = "Total Enemies: 10, Enemies Destroyed = " + mPlanesTouched;
            Destroy(collision.gameObject);
            mGameController.EnemyDestroyed();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpBehavior : MonoBehaviour
{
    
}
