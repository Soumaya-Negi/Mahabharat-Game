using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class TerrainInteractable : MonoBehaviour
{
    public PandavClass RequiredClass; // ✅ Use the same enum as the player

    public void Interact(PandavClass currentPandav)
    {
        if (currentPandav == RequiredClass)
        {
            Debug.Log("Interacted by correct Pandav: " + RequiredClass);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Debug.Log("Only " + RequiredClass + " can interact with this.");
        }
    }

}
