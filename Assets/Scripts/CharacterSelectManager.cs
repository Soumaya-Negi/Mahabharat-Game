using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    // Called by each UI Button (use wrapper methods in the Button OnClick to avoid manual ints)
    public void SelectCharacter(int classIndex)
    {
        Debug.Log($"CharacterSelectManager: button pressed -> index = {classIndex}");
        GameData.SelectedPandav = (PlayerMovement.PandavClass)classIndex;
        Debug.Log("GameData.SelectedPandav set to: " + GameData.SelectedPandav);

        // Persist selection as fallback
        PlayerPrefs.SetInt("SelectedPandav", classIndex);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs Saved SelectedPandav = " + classIndex);

        SceneManager.LoadScene("SampleScene");
    }

    // Wrapper methods to avoid wiring wrong ints in the inspector
    public void SelectArjun() => SelectCharacter((int)PlayerMovement.PandavClass.Arjun);
    public void SelectBheem() => SelectCharacter((int)PlayerMovement.PandavClass.Bheem);
    public void SelectYudhi() => SelectCharacter((int)PlayerMovement.PandavClass.Yudhishthir);
    public void SelectNakul() => SelectCharacter((int)PlayerMovement.PandavClass.Nakul);
    public void SelectSahdev() => SelectCharacter((int)PlayerMovement.PandavClass.Sahdev);
}
