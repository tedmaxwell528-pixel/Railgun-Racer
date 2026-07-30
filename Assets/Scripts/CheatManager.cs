using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheatManager : MonoBehaviour
{
    string killCommand = "";
    List<string> registeredKeys = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detect if user types out "kill"
        if (Keyboard.current.kKey.isPressed){
            registeredKeys.Add("k");
        } else {
            if (registeredKeys.Contains("k")){
                registeredKeys.Clear();
                killCommand += "k";
            }
        }
        if (Keyboard.current.iKey.isPressed){
            registeredKeys.Add("i");
        } else {
            if (registeredKeys.Contains("i")){
                registeredKeys.Clear();
                killCommand += "i";
            }
        }
        if (Keyboard.current.lKey.isPressed){
            registeredKeys.Add("l");
        } else {
            if (registeredKeys.Contains("l")){
                registeredKeys.Clear();
                killCommand += "l";
            }
        }
        if (Keyboard.current.backspaceKey.isPressed){
            killCommand = "";
        }

        if (killCommand == "kill"){
            SceneLoader.EndGame();
        }
    }

}
