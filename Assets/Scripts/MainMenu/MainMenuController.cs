using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Image Pannel;
    public Color low; 
    public Color high;
    public float lerpSpeed = 5.0f;

    private void Update()
    {
       Pannel.color = Color.Lerp(low, high, Time.deltaTime * lerpSpeed);
       
    }
}
