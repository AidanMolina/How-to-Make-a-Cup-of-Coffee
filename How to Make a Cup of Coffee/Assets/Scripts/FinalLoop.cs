using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLoop : MonoBehaviour
{
    string[] Dialogue;
    [SerializeField] GameObject Directions;
    [SerializeField] GameObject CurrentInteractable;
    [SerializeField] GameObject player;
    Collider currentCollider;

    GameObject interactableContainer;

    int dialogueCounter;
    int currentCounter;
    float timer;

    [SerializeField] int levelNumber;

    [SerializeField] Camera mainCamera;
    [SerializeField] Camera secondCamera;

    // Start is called before the first frame update
    void Start()
    {
        interactableContainer = gameObject.transform.GetChild(0).gameObject;
        dialogueCounter = 0;
        currentCounter = 0;
        Dialogue = new string[]{"Bring me my coffee", //0
                                "Oh thanks bro!", //1
                                "Want to see this game I've been making?", //2
                                "You've completed the Demo" //3
        };

        Directions.GetComponent<TMPro.TextMeshProUGUI>().text = Dialogue[dialogueCounter];

        currentCollider = CurrentInteractable.GetComponent<SphereCollider>();
        currentCollider.enabled = !currentCollider.enabled;
        
        mainCamera = Camera.main;
        mainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueCounter >= 3){
            player.transform.position = new Vector3(0f, -20f, 0f);
            secondCamera = Camera.main;
            mainCamera.enabled = false;
            moveCamera();
        }
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

    void moveCamera(){
        timer += Time.deltaTime;
        mainCamera.transform.position += new Vector3(timer, 0f, timer);
        if(timer > 1.46){
            SceneManager.LoadScene(levelNumber);
        }
    }
}
