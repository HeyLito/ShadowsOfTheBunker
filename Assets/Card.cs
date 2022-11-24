using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[SelectionBase]
public class Card : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Card))]
public class CardEditor : Editor
{
    private void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif