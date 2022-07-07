using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   
    public State currentState;

   private void RunStateMachine(){
    
        // o simbolo "?" significa que se a variável, não for nula, vai rodar o currentState se for nula, ignora
        State nextState = currentState?.RunCurrentState();
        if(nextState!=null){
            SwitchToNextState(nextState);
        }
   }
   
   // essa função vai fazer a mudança entre os Estados
   private void SwitchToNextState(State nextState){
        currentState = nextState;
   }
   private void Update() {
        RunStateMachine();
   }
}
