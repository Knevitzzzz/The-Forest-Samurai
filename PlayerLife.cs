using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    //Vida
    public int Vida = 100;

    //Objeto Do Player
    public GameObject Player;

    //Animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      //Busca O Animtaor Anexado Ao Player Com Este Script
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      //Se A Vida Do Player Chegar A 0 Ele É Destruido Simulando A Morte
      if (Vida == 0)
      {
        Destroy(gameObject);
      }
    }
}
