using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonkey : MonoBehaviour
{

    //Muza Gitme İşlemleri
    public GameObject[] bananas;
    Bananas bananasCreateds;
    public bool banana = false;
    public float speed;

    //Muz objesinenin posizyonuna göre yön değiştirme
    private Rigidbody2D myBody;

    //Maymunun canını azaltma değişkenleri

     ScorHealt healt;

    void Start()
    {
        bananasCreateds = GameObject.FindGameObjectWithTag("BananasCreated").GetComponent<Bananas>();

        myBody = this.GetComponent<Rigidbody2D>();

        healt = GameObject.FindGameObjectWithTag("ScorHealt").GetComponent<ScorHealt>();

    }

    
    void Update()
    {

        if(bananasCreateds.GetComponent<Bananas>().bananaCreateds == true)
        {
            bananas = GameObject.FindGameObjectsWithTag("Banana");

            banana = true;

            Debug.LogWarning("Muz oluştu");


            if (banana)
            {
                

                for (int i = 0; i < bananas.Length; i++)
                {
                    bananas[i].transform.Rotate(1, 0, 0);//Ekrandaki muzları x eksenin de döndürüyoruz.
                    if (bananas[i].transform.position != null)
                    {
                        //Muzların konumunu bizim konumdan çıkarıp karakteri muza doğru bir hareket etmesini sağladık
                        //Bunu kontrol etmek için de bir Ray çizdiriyoruz.
                        transform.position = Vector2.MoveTowards(transform.position, bananas[i].transform.position, speed * Time.deltaTime);
                        Debug.DrawLine(transform.position, bananas[i].transform.position, Color.red);

                        //Yönümüzü muzun yönüne doğru çevirme işelmi.
                        Vector3 direction = bananas[i].transform.position - transform.position;
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        myBody.rotation = angle;

                        //Bir muz algılandıkdan sonra döngümüzü bitiriyoruz.
                        banana = false;
                        break;



                    }
                }




            }



        }

        else if(bananasCreateds.GetComponent<Bananas>().bananaCreateds == false)
        {
            banana = false;
        }


        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);

            healt.ReduceHealt(5);
        }
    }
}
