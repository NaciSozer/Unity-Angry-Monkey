using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyControls : MonoBehaviour
{



    //Farenin yönü
    //public GameObject hedefTopu;
    Vector3 hedefTopunKonumu;

    //Karakterin fareye yöre yönü
    public GameObject Player;

    //Mermi atma sistemi
    public GameObject mermi;
    public float mermiHizi;
    public GameObject mermiBaslangici;



    void Update()
    {



        //Farenin posisyonunun bulunduğu yere hedefTopunu koyduk yani fare nereye giderse topda oraya gidiyor
        Vector3 fareninPozisyonlari = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        hedefTopunKonumu = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(fareninPozisyonlari.x, fareninPozisyonlari.y, fareninPozisyonlari.z));
        //hedefTopu.transform.position = new Vector2(hedefTopunKonumu.x, hedefTopunKonumu.y);

        //Player nesnesinin fareye göre dönme işlemi
        Vector3 hedefTopilePlayerArasindakiFark = hedefTopunKonumu - Player.transform.position;
        float zRotasyonu = Mathf.Atan2(hedefTopilePlayerArasindakiFark.y, hedefTopilePlayerArasindakiFark.x) * Mathf.Rad2Deg;
        Player.transform.rotation = Quaternion.Euler(0, 0, zRotasyonu);


        if (Input.GetMouseButtonDown(0))
        {
            float mesafe = hedefTopilePlayerArasindakiFark.magnitude;
            Vector2 yon = hedefTopilePlayerArasindakiFark / mesafe;
            yon.Normalize();
            Fire(yon, zRotasyonu);
        }




    }


    private void Fire(Vector2 yon, float zRotaiton)
    {


        GameObject mermimiz = Instantiate(mermi);
        mermi.transform.position = mermiBaslangici.transform.position;
        mermi.transform.rotation = Quaternion.Euler(0, 0, zRotaiton);
        mermimiz.GetComponent<Rigidbody2D>().velocity = yon * mermiHizi;


        //mermi.GetComponent<Rigidbody2D>().velocity = yon * mermiHizi;
        //GameObject b = Instantiate(mermiPrefab) as GameObject;
        //b.transform.position = MermiStart.transform.position;
        //b.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        //b.GetComponent<Rigidbody2D>().velocity = direction * MermiHizi;

    }

}
