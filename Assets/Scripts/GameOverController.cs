using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


// TODO : Singleton yap
public class GameOverController : MonoBehaviour
{
    [SerializeField] HeroMovementController heroMovementController;
    [SerializeField] GameObject FailedScreen;
    [SerializeField] TextMeshProUGUI FailedScreenScore;

    [SerializeField] GameObject SuccessScreen;
    [SerializeField] TextMeshProUGUI SuccessScreenScore;

    [SerializeField] HeroGemsController heroGemsController;




    public void EndOfChapter(){
        ResetMovement();
        SuccessScreenScore.text = heroGemsController.GemsCounter.ToString();
        SuccessScreen.SetActive(true);

    }
    public void FailedChapter(){
        ResetMovement();
        FailedScreenScore.text = heroGemsController.GemsCounter.ToString();
        FailedScreen.SetActive(true);
    }
    private void ResetMovement(){
        heroMovementController.forwardMovementSpeed = 0;
        heroMovementController.horizontalMovementSpeed = 0;
    }

    public void RestartChapter(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static GameOverController Instance { get; private set; }
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
