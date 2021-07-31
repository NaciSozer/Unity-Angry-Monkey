using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : MonoBehaviour
{
    public GameObject banana;

    float vec_x, vec_y;

    public static int bananaNumber;

    public bool bananaCreateds;




    void Update()
    {

        //Muzların ekran da rasgele bölgelerde çıkmasını sağlama
        vec_x = Random.Range(-8.55f, 8.41f);
        vec_y = Random.Range(-4.48f, 4.32f);

        if (Input.GetKeyDown(KeyCode.S))
        {
            MuzOlustur();

        }

        if(bananaNumber > 0)
        {
            bananaCreateds = true;
        }

        else if(bananaNumber == 0)
        {
            bananaCreateds= false;
        }

    }


    void MuzOlustur()
    {
        bananaNumber++;
        Instantiate(banana, new Vector2(vec_x, vec_y), Quaternion.identity);

        Debug.Log(bananaNumber + "Kadar muz var");
    }

    public void BananaReduce()//Sahnede muz sayısını azaltmak için.
    {
        bananaNumber--;
    }


}
