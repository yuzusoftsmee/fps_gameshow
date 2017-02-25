using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    private Animator animator_hand;
    private Animator animator_sward;
    bool gun_stance = false;


    public GameObject shgit;
    public GameObject sna;
    public GameObject hand;
    public GameObject sword;

    public float pov;
    public float pov_2 = 50f;
    public int Wepon = 0; //0:ハンドガン1:スナイパー2:ナイフ

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

    int i = 0;
    public bool magazine_yes = true;


    public int magazine_num_hand_max = 32;
    public int magazine_num_sna_max = 12;

    private int magazine_num_hand;
    private int magazine_num_sna;

    public int magazine_num = 32;
    public int magazine_num_max = 32;
    bool re = false;
    public bool shoot_yes = true;

    float shoot_no_time = 2.5f;
    float tim = 0;









    // Use this for initialization
    void Start()
    {

        animator_hand = hand.GetComponent<Animator>();
        animator_sward = sword.GetComponent<Animator>();
        //animator = GetComponent(typeof(Animator)) as Animator;

        muzzle = muzzle_1;
        bulletSpeed = bulledSpead_hand;
        bullet = bullet_1;

        hand.SetActive(true);
        sna.SetActive(false);
        sword.SetActive(false);


        magazine_num = magazine_num_hand_max;
        magazine_num_max = magazine_num_hand_max;
        magazine_num_hand = magazine_num_hand_max;
        magazine_num_sna = magazine_num_sna_max;


    }

    // Update is called once per frame
    void Update()
    {

        Wepon_State();
        Action();
        Constant_Control();






    }


    void Shoot(int mag_num)
    {


        if (mag_num > 0 && shoot_yes)
        {

            //弾丸を作成する
            GameObject b = GameObject.Instantiate(bullet, muzzle.position, Quaternion.identity) as GameObject;//GameObject型に変換する。

            //銃口の前方にbulletSpeed分の力を加える。


            // b.rigidbody.AddForce(muzzle.forward * bulletSpeed);

            rb = b.GetComponent<Rigidbody>();
            rb.AddForce(muzzle.forward * bulletSpeed);


            magazine_num--;
        }



    }

    void Action()
    {
        if (Wepon == 0)

        {


            if (Input.GetMouseButtonDown(0) && shoot_yes)
            {
                animator_hand.Play("gun_shot_1");

                Shoot(magazine_num);
            }

            if (Input.GetMouseButtonDown(1))

            {
                animator_hand.Play("gun_stance");
                gun_stance = true;
            }

            if (Input.GetMouseButtonUp(1))

            {
                animator_hand.Play("gun_stance_3");
                gun_stance = false;
            }


            if (Input.GetKeyDown("r"))
            {
                animator_hand.Play("reload_ani");
                Reload();
            }

            if(Input.GetMouseButton(1))

            {
                camera_.fieldOfView = pov_2;
            }
            else
            {
                camera_.fieldOfView = 60;
            }
        }


        if (Wepon == 1)

        {

            if (Input.GetMouseButtonDown(0))
            {
                Shoot(magazine_num);
            }
            if (Input.GetMouseButton(0) && Input.GetKey("c"))
            {
                i++;
                if (i == 5)
                {
                    Shoot(magazine_num);
                    i = 0;
                }
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

            if (Input.GetKeyDown("r"))
            {
                Reload();
            }

        }

        if (Wepon == 2)

        {

            if (Input.GetMouseButtonDown(0))
            {

                animator_sward.Play("sword_ani");

            }

            if (Input.GetMouseButtonDown(1))
            {

                animator_sward.Play("sword_ani_2");
            }

        }


    }

    void Wepon_State()
    {
        if (Input.GetKeyDown("1"))
        {
            Wepon = 0;
            hand.SetActive(true);
            sna.SetActive(false);
            sword.SetActive(false);
            Debug.Log(Wepon);

            muzzle = muzzle_1;
            bulletSpeed = bulledSpead_hand;
            bullet = bullet_1;

            magazine_num = magazine_num_hand;
            magazine_num_max = magazine_num_hand_max;

        }


        if (Input.GetKeyDown("2"))
        {
            Wepon = 1;
            sna.SetActive(true);
            hand.SetActive(false);
            sword.SetActive(false);
            Debug.Log(Wepon);

            muzzle = muzzle_2;
            bulletSpeed = bulledSpead_sna;
            bullet = bullet_2;

            magazine_num = magazine_num_sna;
            magazine_num_max = magazine_num_sna_max;
        }

        if (Input.GetKeyDown("3"))
        {
            Wepon = 2;
            sword.SetActive(true);
            sna.SetActive(false);
            hand.SetActive(false);
            Debug.Log(Wepon);

            magazine_num = 0;
            magazine_num_max = 0;
        }
    }

    void Constant_Control()
    {
        if (magazine_num_hand < 0)
            magazine_num_hand = 0;
        if (magazine_num_sna < 0)
            magazine_num_sna = 0;

        if (magazine_num == 0)
            magazine_yes = false;
        else
            magazine_yes = true;


        switch (Wepon)
        {
            case 0:
                magazine_num_hand = magazine_num;
                break;
            case 1:
                magazine_num_sna = magazine_num;
                break;
        }


        tim += Time.deltaTime;
        if (tim > shoot_no_time)
        {
            shoot_yes = true;
            tim = 0;
        }


    }

    void Reload()
    {
        magazine_num = magazine_num_max;

       shoot_yes = false;

    }

    bool Ani_now(int ani)
    {
        /* 
        switch (ani)
        {
            case 0:
                re = animator_hand.GetCurrentAnimatorStateInfo(0).IsName("reloard_ani");
                break;
        }
        */
        return re;
        
    }

}



