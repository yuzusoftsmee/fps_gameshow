using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {


    private Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        anim = GetComponent<Animator>();

	}

    void OnTriggerEnter(Collider hit)
    {


       

        //もし当たったオブジェクトがEnemyタグである(＝敵である)場合は、敵削除

        if (hit.tag == "Enemy" )

            //anim再生中なら
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("sword_ani") || anim.GetCurrentAnimatorStateInfo(0).IsName("sword_ani_2"))
            {
                Destroy(hit.gameObject);
                Debug.Log("当たった");
            }
        }
    }
}
