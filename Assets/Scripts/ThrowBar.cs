using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowBar : MonoBehaviour
{
    public Player player;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.value = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = player.throwStrength / player.maxThrow;
    }
}
