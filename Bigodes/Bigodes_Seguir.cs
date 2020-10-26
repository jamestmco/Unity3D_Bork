using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigodes_Seguir : StateMachineBehaviour
{
    Transform jogador;
    Rigidbody corpo;
    public float velocidade = 2f;
    public float velocidadeIrritado = 3f;
    public float alcanceAtaque = 2f;
    public float alcanceAtaque2 = 4f;
    public float alcanceSonico = 7f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        corpo = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 novaPosicao = Vector3.MoveTowards(corpo.position, jogador.position, velocidade * Time.fixedDeltaTime);
        animator.transform.LookAt(jogador);
        animator.transform.Rotate(0, 90, 0);
        corpo.MovePosition(novaPosicao);
        if (Vector3.Distance(jogador.position, corpo.position) <= alcanceAtaque)
        {
            animator.SetTrigger("BigodeLigeiro");
        }
        if(Vector3.Distance(jogador.position, corpo.position) <= alcanceAtaque2)
        {
            animator.SetTrigger("BigodeForte");         
        }
        if (Vector3.Distance(jogador.position, corpo.position) <= alcanceSonico)
        {
            animator.SetTrigger("BigodeSonico");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("BigodeLigeiro");
        animator.ResetTrigger("BigodeForte");
        animator.ResetTrigger("BigodeSonico");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
