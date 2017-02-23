using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour {

     private Animator animator;
    bool gun_stance = false;


    public GameObject shgit;
    public GameObject sna;
    public GameObject hand;
    public float pov;
    private int Wepon = 0; //0:ハンドガン1:スナイパー2:ナイフ

    public Camera camera_;

    private GameObject bullet;
    public GameObject bullet_1;
    public GameObject bullet_2;

    public Transform muzzle_1;
    public Transform muzzle_2;


    private Transform muzzle;
    private float bulletSpeed;
    public float bulledSpead_hand;
    public float bulledSpead_sna;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {

        animator = hand.GetComponent<Animator>();
        //animator = GetComponent(typeof(Animator)) as Animator;

        muzzle = muzzle_1;
        bulletSpeed = bulledSpead_hand;
        bullet = bullet_1;
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown("1"))
        {
            Wepon = 0;
            hand.SetActive(true);
            sna.SetActive(false);
            Debug.Log(Wepon);

            muzzle = muzzle_1;
            bulletSpeed = bulledSpead_hand;
            bullet = bullet_1;
        }


        if (Input.GetKeyDown("2"))
        {
            Wepon = 1;
            sna.SetActive(true);
            hand.SetActive(false);
            Debug.Log(Wepon);

            muzzle = muzzle_2;
            bulletSpeed = bulledSpead_sna;
            bullet = bullet_2;
        }

        if(Input.GetKeyDown("3"))
        {
            Wepon = 2;

        }


        if(Wepon == 0)

        {


            if (Input.GetMouseButtonDown(0))
            {
                animator.Play("gun_shot_1");

                Shoot();
            }

            if (Input.GetMouseButtonDown(1))

            {
                animator.Play("gun_stance");
                gun_stance = true;
            }

            if (Input.GetMouseButtonUp(1))

            {
                animator.Play("gun_stance_3");
                gun_stance = false;
            }


            if (Input.GetKeyDown("r"))
            {
                animator.Play("reload_ani");
            }

        }


        if (Wepon == 1)

        {

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            if (Input.GetMouseButton(1))
            {
                sna.SetActive(false);
                shgit.SetActive(true);
                camera_.fieldOfView = pov;
            }

            else

            {
                sna.SetActive(true);
                shgit.SetActive(false);
                camera_.fieldOfView = 60;
            }

        }



    }


    void Shoot()
    {
        //弾丸を作成する
        GameObject b = GameObject.Instantiate(bullet, muzzle.position, Quaternion.identity) as GameObject;//GameObject型に変換する。

        //銃口の前方にbulletSpeed分の力を加える。


        // b.rigidbody.AddForce(muzzle.forward * bulletSpeed);

        rb = b.GetComponent<Rigidbody>();
        rb.AddForce(muzzle.forward * bulletSpeed);
    }
}
