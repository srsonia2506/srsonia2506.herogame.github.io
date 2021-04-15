using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDelete : MonoBehaviour
{
    Renderer rend;
    private int hitNum = 4;
    private GameController gameController = null;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {

    }

    IEnumerator Fade(GameObject g)
    {
        rend = g.GetComponent<Renderer>();
        Color c = rend.material.color;
        c.a *= .8f;
        rend.material.color = c;
        yield return new WaitForSeconds(.8f);
    }

    public void startFade(GameObject g)
    {
        StartCoroutine("Fade", g);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            --hitNum;
            startFade(gameObject);
            Destroy(collision.gameObject);
            if (hitNum <= 0)
            {
                Destroy(gameObject);
                mGameController.EnemyDestroyed();
            }
        }
    }
}