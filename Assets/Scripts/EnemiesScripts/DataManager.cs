using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DataManager : MonoBehaviour
{
    public int data=0;

    public void addData(){
        data++;
    }
    void OnShinka(){
       if(data==2) 
        {Debug.Log("EVOLUI!");}
    }

    public int GetData(){
        return data;
    }

}
