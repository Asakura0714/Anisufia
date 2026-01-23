using TMPro;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [SerializeField] ScreenTransition _fadeOut = default;
    [SerializeField] ScreenTransition _fadeIn = default;
    [SerializeField] private TextMeshProUGUI _textMesh;

    public ScreenTransition FadeOut => _fadeOut;
    public ScreenTransition FadeIn => _fadeIn;
}
