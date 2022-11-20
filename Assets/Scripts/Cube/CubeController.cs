using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //Sil Singleton yap
    [SerializeField] HeroStackController heroStackController;
    [SerializeField] private Vector3 direction = Vector3.back;
    [SerializeField] private bool isStack = false;
    private RaycastHit hit;


    private void SetCubeRaycast()
    {
        
        HorizontalRayCast();

        //lav için 
        VerticalRaycast();
        

    }
    
    RaycastHit[] hits = new RaycastHit[10];
    private void HorizontalRayCast(){
        if(Physics.RaycastNonAlloc(transform.position, direction, hits,1f) > 0){
            hit = hits [0];
            // sadece toplanabilir küpler için
            if(!isStack){
                isStack = true;
                heroStackController.IncreaseCubeStack(gameObject);
                direction = Vector3.forward;
            }

            //sadece stacktaki küpler için geçerli
            if(hit.transform.CompareTag("Wall")){
                heroStackController.DecreaseCubeStack(gameObject);
            }
            else if(hit.transform.CompareTag("Gem")){
                HeroGemsController.Instance.CollectGem(hit.transform.gameObject);
            }
        }
    }
    private void VerticalRaycast(){
        int cnt;
        if((cnt = Physics.RaycastNonAlloc(transform.position, Vector3.down, hits, 1f) ) > 0){
            hit = hits [cnt - 1];
            
            if(isStack && hit.transform.CompareTag("Fire")){
                heroStackController.DestroyLastCube(gameObject);
            }
            if(isStack && hit.transform.CompareTag("FinalZone")){
                GameOverController.Instance.EndOfChapter();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCubeRaycast();
    }
}
