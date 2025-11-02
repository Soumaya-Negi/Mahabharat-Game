using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    [System.Serializable]
    public class CharSlot
    {
        public Button button;
        public Image portrait;
        public string description;
        public PlayerMovement.PandavClass pandav;
    }

    public CharSlot[] slots;
    public Image largePortrait;
    public TMPro.TextMeshProUGUI descriptionText;
    public Button confirmButton;
    public AudioClip selectSfx;
    private AudioSource src;
    private PlayerMovement.PandavClass? selected = null;
    private Color normal = Color.white;
    private Color highlighted = Color.yellow;

    void Awake()
    {
        src = gameObject.AddComponent<AudioSource>();
        confirmButton.interactable = false;

        foreach (var s in slots)
        {
            var p = s;
            p.button.onClick.AddListener(() => OnSlotClicked(p));
        }
    }

    void OnSlotClicked(CharSlot slot)
    {
        selected = slot.pandav;
        UpdateUI(slot);
        confirmButton.interactable = true;
        src.PlayOneShot(selectSfx);
    }

    void UpdateUI(CharSlot slot)
    {
        // highlight all slots correctly
        foreach (var s in slots)
        {
            var colors = s.button.colors;
            colors.normalColor = (s == slot) ? highlighted : normal;
            s.button.colors = colors;
        }

        // set preview
        if (largePortrait != null) largePortrait.sprite = slot.portrait.sprite;
        if (descriptionText != null) descriptionText.text = slot.description;
    }

    // Called by Confirm button - uses CharacterSelectManager wrapper
    public void ConfirmSelection()
    {
        if (selected == null) return;
        var manager = FindObjectOfType<CharacterSelectManager>();
        if (manager == null)
        {
            Debug.LogError("No CharacterSelectManager in scene.");
            return;
        }
        // call the wrapper via the enum index
        manager.SelectCharacter((int)selected.Value);
    }
}
