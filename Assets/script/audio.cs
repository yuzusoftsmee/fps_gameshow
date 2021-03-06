﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{

    private AudioSource sound01_relo;
    private AudioSource sound02_shot;
    private AudioSource sound03_stance;
    private AudioSource sound03_stance_end;


    public gamemanager GM;

    int i = 0;

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01_relo = audioSources[0];
        sound02_shot = audioSources[1];
        sound03_stance = audioSources[2];
        sound03_stance_end = audioSources[3];

    }

    void Update()
    {

        if (GM.Wepon == 0 || GM.Wepon == 1)
        {
            //指定のキーが押されたら音声ファイル再生
            if (Input.GetKeyDown("r"))
            {
                sound01_relo.PlayOneShot(sound01_relo.clip);

            }
            if (Input.GetMouseButtonDown(0) && GM.magazine_yes && GM.shoot_yes)
            {
                sound02_shot.PlayOneShot(sound02_shot.clip);
            }
            if (Input.GetMouseButtonDown(1))

            {
                sound03_stance.PlayOneShot(sound03_stance.clip);
            }

            if (Input.GetMouseButtonUp(1))

            {
                sound03_stance_end.PlayOneShot(sound03_stance_end.clip);
            }
        }

        if (GM.Wepon == 1)
        {

            if (Input.GetMouseButton(0) && Input.GetKey("c") && GM.magazine_yes)
            {
                i++;
                if (i == 5)
                {
                    sound02_shot.PlayOneShot(sound02_shot.clip);
                    i = 0;
                }

            }

        }
    } 
}
