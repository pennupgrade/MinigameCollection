using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : StateMachineBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Destroy(animator.gameObject, stateInfo.length);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
