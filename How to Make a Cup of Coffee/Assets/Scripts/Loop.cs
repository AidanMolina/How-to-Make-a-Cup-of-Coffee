using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loop : MonoBehaviour
{
    string[] Dialogue;
    [SerializeField] GameObject Directions;
    [SerializeField] GameObject CurrentInteractable;
    Collider currentCollider;

    GameObject interactableContainer;

    int dialogueCounter;
    int currentCounter;

    // Start is called before the first frame update
    void Start()
    {
        interactableContainer = gameObject.transform.GetChild(0).gameObject;
        dialogueCounter = 0;
        currentCounter = 0;
        Dialogue = new string[]{"Grab a Coffee Filter", //0
                    "Put Coffee Filter in Coffee Maker", //1
                    "Grab Coffee Grounds", //2
                    "Put Coffee Grounds in Coffee Maker", //3
                    "Grab Water", //4
                    "Put Water in Coffee Maker", //5
                    "Turn on Coffee Maker", //6
                    "Grab Coffee Pot", //7
                    "Pour Coffee into Mug", //8
                    "Grab Creamer", //9
                    "Put Creamer in Mug", //10
                    "Grab Sugar", //11
                    "Put Sugar in Mug", //12
                    "Stir", //13
                    "Leave Room With Coffee", //14
                    "Left" //15
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

        if(dialogueCounter <= 14){
            dialogueCounter += 1;
        }
        if(dialogueCounter == 15){
            SceneManager.LoadScene(0);
        }
        if(currentCounter <= 13){
            currentCounter += 1;
        }

        Directions.GetComponent<TMPro.TextMeshProUGUI>().text = Dialogue[dialogueCounter];
        
        CurrentInteractable = interactableContainer.transform.GetChild(currentCounter).gameObject;
        currentCollider = CurrentInteractable.GetComponent<SphereCollider>();
        currentCollider.enabled = !currentCollider.enabled;

        interactable.SetActive(false);
    }
}
