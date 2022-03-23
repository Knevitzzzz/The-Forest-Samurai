using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variáveis De Movimentação Do Player
    public float MovementSpeed;
    
    //Variáveis De Pulo Do Player
    public float JumpForce;
    public bool isJumping;

    //RigidBody
    private Rigidbody2D rig;

    //Animator
    private Animator anim;

    //Para Limitar Suas Movimentações
    public bool PlayerPodeSeMover = true;

    void Start()
    {
      //Busca o Rigidbody anexado no Player com este script 
      rig = GetComponent<Rigidbody2D>();

      //Busca o Animator anexado no Player com este script
      anim = GetComponent<Animator>(); 
    }

    void Update() 
    {
      //Determina Os Voids De Pulo E Movimentação Para Poderem Ser Usados
      Move();
      Jump();  
    }

    //Faz O Player Se Mover
    void Move()
    {
      //Toda Vez Que O Player Pode Se Mover
      if (PlayerPodeSeMover == true)
      {
        //O Vector3 É Criado Ao Apertar As Teclas Anexadas Ao Input "Horzizontal" 
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0f , 0f);
       
        //Player É Ajustado Na Posição Do Vector3 E Libera Os Movimentos Para X e Y
        transform.position += movement * Time.deltaTime * MovementSpeed;
      }

       if (PlayerPodeSeMover == true)
       {
          //O "> 0" Determina Que O Player Ira Andar Para Direita
          //Ao Apertar As Teclas Anexadas Ao Input "Horizontal"
          if (Input.GetAxis("Horizontal") > 0f )
          {
            //Aciona A Animação De Correr/Andar Para A Direita
            anim.SetBool("Run", true); 
        
            //Desinverte O Sprite Caso Esteja Invertido
            transform.eulerAngles = new Vector3 (0f,0f,0f);
          }
       }

       if (PlayerPodeSeMover == true)
       {
          //O "< 0" Determina Que O Player Ira Andar Para Esquerda Para Esquerda
          //Ao Apertar As Teclas Anexadas Ao Input "Horizontal"
          if (Input.GetAxis("Horizontal") < 0f )
          {
            //Inverte O Sprite
            transform.eulerAngles = new Vector3 (0f,180f,0f); 
    
            anim.SetBool("Run", true); 
          }
       }
 
       //O "== 0" Determina Que O Player Está Parado E Irá Fazer A Animação De Status Parado
       if (Input.GetAxis("Horizontal") == 0f )
       {
         //Aciona A Animação De Status Parado
         anim.SetBool("Run", false); 
       }   
    }

    //Faz O Player Pular
    void Jump()
    {
      //Se Ele Pode Se Mover
      if (PlayerPodeSeMover == true)
      {
        //E Não Estiver No Ar E Apertar As Teclas Anexadas Ao Input "Jump"
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
          //Ele Ganha Um Impulso A Partir Do "JumpForce" Determinado No Inspector Dando O Efeito De Pulo 
          rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        } 
      }
    } 

    //Para Determinar Que O Player Não Está Pulando
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Se O Player Estiver Colidindo Com Algum Objeto Da Layer 8
        if(collision.gameObject.layer == 8)
        {
            //É Determinado Que Ele Não Está Pulando
            isJumping = false;

            //Desativa A Animação De Pulo 
            anim.SetBool("Jump", false);
        }
    }

    //Para Determinar Que O Player Está Pulando
    void OnCollisionExit2D(Collision2D collision)
    {
        //Se O Player Não Estiver Colidindo Com Algum Objeto Da Layer 8
        if(collision.gameObject.layer == 8)
        {
          //É Determinado Que Ele Está Pulando
          isJumping = true;
          
          //Aciona A Animação De Pulo 
          anim.SetBool("Jump", true);
        }
    }
}
