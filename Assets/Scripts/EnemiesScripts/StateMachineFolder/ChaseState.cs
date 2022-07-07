using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isAttackRange;
    
    public override State RunCurrentState()
    {
       if(isAttackRange){
        return attackState;
       }
       else{
        return this;
       }
    }
}
