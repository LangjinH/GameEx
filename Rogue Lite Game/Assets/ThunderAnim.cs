using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAnim : StateMachineBehaviour
{
    GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject clone = Instantiate(player.GetComponentInChildren<Thunder>().thunderStrike, player.GetComponentInChildren<Thunder>().attackPos.position, player.GetComponentInChildren<Thunder>().transform.rotation);
        clone.SetActive(true);
        player.GetComponentInChildren<Thunder>().AttackCircle();
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
