﻿using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

//Dylan G

public class wave_spawner : MonoBehaviour
{
    public enum spawn_state { spawning, waiting, counting };

    public TextMeshProUGUI zombies_alive;

    public TextMeshProUGUI wave_timer;

    public int health_buff = 5;
    public int dmg_buff = 3;

    public GameObject enemy;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float spawn_rate;
    }        

    public Wave[] waves;
    private int next_wave = 0;

    public Transform[] spawn_points;


    public float time_between_waves = 10;
    public float wave_count_down;

    private float check_timer = 1f;

    private spawn_state state = spawn_state.counting;


    private void Start()
    {

        wave_count_down = time_between_waves;



    }

    private void Update()
    {
        wave_timer.text = "Next Wave spawning in: " + (int)wave_count_down;


        zombies_alive.text = "zombies: " + GameObject.FindGameObjectsWithTag("Enemy").Length;


        if(state == spawn_state.waiting)
        {
            if (!enemy_alive())
            {
                wave_complete();
            }
            else
            {
                return;
            }
        }

        if(wave_count_down <= 0  && state != spawn_state.spawning)
        {
            wave_timer.enabled = false;
            StartCoroutine(Spawn_wave (waves[next_wave]));
        }
        else
        {
            wave_count_down -= Time.deltaTime;
        }
    }

    void wave_complete()
    {

        state = spawn_state.counting;
        wave_timer.enabled = true;
        wave_timer.text = "Next Wave spawning in: " + wave_count_down;

        wave_count_down = time_between_waves;

        if(next_wave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene("wins");
        }
        else
        {

            enemy.GetComponent<Enemy1>().max_health += (health_buff * waves.Length);
            GameObject.FindGameObjectWithTag("gun").GetComponent<Gun>().dmg += (dmg_buff * waves.Length);
            next_wave++;
            

        }

    }

    bool enemy_alive()
    {
        check_timer -= Time.deltaTime;
        if (check_timer <= 0)
        {
            check_timer = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }


    IEnumerator Spawn_wave(Wave current_wave)
    {
        state = spawn_state.spawning;

        for(int i = 0; i < current_wave.count; i++)
        {
            spawn(current_wave.enemy);
            yield return new WaitForSeconds(1f / current_wave.spawn_rate);
        }

        state = spawn_state.waiting;
        yield break;
    }


    void spawn(Transform enemy)
    {
        Transform ran_point = spawn_points[ Random.Range (0, spawn_points.Length)];

        Instantiate(enemy, ran_point.position, ran_point.rotation);

    }


}