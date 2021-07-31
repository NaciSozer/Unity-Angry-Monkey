using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprear : MonoBehaviour
{

    Bananas bananaReduce;
    ScorHealt scor;

    private void Start()
    {

        bananaReduce = GameObject.Find("BananasCreated").GetComponent<Bananas>();

        scor = GameObject.FindGameObjectWithTag("ScorHealt").GetComponent<ScorHealt>();

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Duvar"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Banana"))
        {
            bananaReduce.BananaReduce();

            scor.ScorAdd(1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }


}
