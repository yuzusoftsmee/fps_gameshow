using UnityEngine;
using System.Collections;

//主な機能
//一定時間後に弾丸を消すようにする
//何か(敵や、壁)に当たったら、弾丸を削除する。
//敵に当たったら、Damage関数を実行するようにする。
public class bullet : MonoBehaviour
{

    //自動削除されるまでの時間
    public float destroyTime = 3;

    //このオブジェクト(Bullet)が生成された瞬間に実行される。
    void Start()
    {
        //このオブジェクトをdestroyTimeで指定した秒後に削除する。
        Destroy(gameObject, destroyTime);
    }

    //何かにぶつかったら実行される。(hit変数内に当たったオブジェクトに関する情報が代入されている。)
    void OnTriggerEnter(Collider hit)
    {


        //このオブジェクト(弾丸)を削除する。
        Destroy(gameObject);

        //もし当たったオブジェクトがEnemyタグである(＝敵である)場合は、敵のDamage関数を実行する。
        if (hit.tag == "Enemy")
        {
            //Damage関数を実行させる。
            //hit.SendMessage("Damage");
            Destroy(hit.gameObject);
            Debug.Log("当たった");
        }
    }
}