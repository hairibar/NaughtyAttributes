using NaughtyAttributes;
using UnityEngine;

public class NonLinearSliderTest : MonoBehaviour
{
    [QuadraticSlider(0, 1, 2)] public float quadraticFloat;
}
