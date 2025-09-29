using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioSource;   // assign an AudioSource in inspector
    public AudioClip hoverClip;       // sound when hovering
    public AudioClip clickClip;       // sound when clicking

    private Button button;

    void Start()
    {
        // Get the Button component on this object
        button = GetComponent<Button>();

        // Add a listener for the click event
        button.onClick.AddListener(OnClick);
    }

    // Hover sound
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverClip);
    }

    // Click sound
    void OnClick()
    {
        audioSource.PlayOneShot(clickClip);
    }
}

