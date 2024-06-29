using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BolsaStack bolsaStack;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            bolsaStack.AddBag();
        }
    }
}
