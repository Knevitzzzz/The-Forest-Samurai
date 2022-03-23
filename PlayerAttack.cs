using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Animator
    private Animator anim;

    //Variáveis De Ataque
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemysLayer;

    // Start is called before the first frame update
    void Start()
    {
      //Busca o Animator anexado no Player com este script
      anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("e"))
      {
        Atack();
      }
    }

    //Faz O Jogador Atacar
    void Atack()
    {
        //Ativa A Animação De Ataque
        anim.SetTrigger("Attack");

      //Detecta Os Inimigos No Alcance Do Ataque
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemysLayer);

      //Acerta Os Inimigos E Os Causa Dano
      foreach (Collider2D enemy in hitEnemies)
      {
        Debug.Log("We Hit" + enemy.name); 
        FindObjectOfType<EnemyLife>().enemyLife -= 100;
      }
    }

    void OnDrawGizmosSelected() 
    {
      if (AttackPoint == null)
          return;


      Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
