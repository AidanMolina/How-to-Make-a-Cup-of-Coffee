using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject label;
    [SerializeField] GameObject loop;

    // Start is called before the first frame update
    void Start()
    {
        label.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter(){
        label.GetComponent<TMPro.TextMeshProUGUI>().text = name;
    }

    void OnMouseExit(){
        label.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    void OnMouseDown(){
        label.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        StartCoroutine(loop.GetComponent<Loop>().InteractableSelected(gameObject));
    }
}
