using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeInteractable : MonoBehaviour
{
    [SerializeField] GameObject label;
    [SerializeField] GameObject loop;
    [SerializeField] GameObject fridge;
    [SerializeField] GameObject player;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        label.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }

    void OnMouseEnter(){
        label.GetComponent<TMPro.TextMeshProUGUI>().text = name;
    }

    void OnMouseExit(){
        label.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    void OnMouseDown(){
        fridge.transform.Rotate(0f, 90f, 0f);
        fridge.transform.position += new Vector3(1f, 0f, -0.8f);
        label.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        StartCoroutine(loop.GetComponent<Loop>().InteractableSelected(gameObject));
    }
}
