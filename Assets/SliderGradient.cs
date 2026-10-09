using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]

public class SliderGradient : MonoBehaviour
{
    private Slider slider;
    public Image fillRenderer;
    public Gradient gradient;
    // Update is called once per frame
    void Awake()
    {
        slider=gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnUpdate);
    }
    void OnUpdate(float val)
    {
        fillRenderer.color=gradient.Evaluate(val);
    }
}
