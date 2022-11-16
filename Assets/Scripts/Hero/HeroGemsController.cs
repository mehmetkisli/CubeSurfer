using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroGemsController : MonoBehaviour
{
    private int GemsCounter = 0;
    [SerializeField] TextMeshProUGUI GemsText;

    public void CollectGem(GameObject _gameObject){
        GemsCounter++;
        GemsText.text = GemsCounter.ToString();
        Destroy(_gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        GemsText.text = GemsCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public static HeroGemsController Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
}
