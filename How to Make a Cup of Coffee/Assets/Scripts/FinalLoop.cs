using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLoop : MonoBehaviour
{
    string[] Dialogue;
    [SerializeField] GameObject Directions;
    [SerializeField] GameObject CurrentInteractable;
    Collider currentCollider;

    GameObject interactableContainer;

    int dialogueCounter;
    int currentCounter;

    [SerializeField] int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        interactableContainer = gameObject.transform.GetChild(0).gameObject;
        dialogueCounter = 0;
        currentCounter = 0;
        Dialogue = new string[]{"Bring me my coffee", //0
                                "Oh thanks bro!", //1
                                "Want to see this game I've been making?" //2
        };

        Directions.GetComponent<TMPro.TextMeshProUGUI>().text = Dialogue[dialogueCounter];

        currentCollider = CurrentInteractable.GetComponent<SphereCollider>();
        currentCollider.enabled = !currentCollider.enabled;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator InteractableSelected(GameObject interactable){
        yield return new WaitForEndOfFrame();

        if(dialogueCounter <= 2){
            dialogueCounter += 1;
        }
        if(currentCounter <= 1){
            currentCounter += 1;
        }

        Directions.GetComponent<TMPro.TextMeshProUGUI>().text = Dialogue[dialogueCounter];
        
        CurrentInteractable = interactableContainer.transform.GetChild(currentCounter).gameObject;
        currentCollider = CurrentInteractable.GetComponent<SphereCollider>();
        currentCollider.enabled = !currentCollider.enabled;

        interactable.SetActive(false);
    }
}
