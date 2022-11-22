using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HeroStackController : MonoBehaviour
{

    public List<GameObject> cubeList = new List<GameObject>();

    public GameObject lastCubeObject; // should be pirvates



    private void UpdateLastCubeObject(){
        if(cubeList.Count == 0){
           GameOverController.Instance.FailedChapter();
           return;
        }
        lastCubeObject = cubeList[cubeList.Count-1];
    }

    public void IncreaseCubeStack(GameObject _gameObject){
        //transform.DOMove(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z),0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastCubeObject.transform.position.x, lastCubeObject.transform.position.y -2f, lastCubeObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        cubeList.Add(_gameObject);
        UpdateLastCubeObject();
    }
    public void DecreaseCubeStack(GameObject _gameObject){
        if(_gameObject.transform.parent != null){
            GameOverController.Instance.animator.SetTrigger("Landing");
            _gameObject.transform.parent = null;
            cubeList.Remove(_gameObject);
            UpdateLastCubeObject();
        }
    }

    public void DestroyLastCube(GameObject _gameObject){
        cubeList.Remove(_gameObject);
        Destroy(_gameObject,2f);
        _gameObject.transform.parent = null;
        _gameObject.transform.DOMove(_gameObject.transform.position + new Vector3(0f, -3f, 2f), 0.5f);
        UpdateLastCubeObject();
        
    }
    



    // Start is called before the first frame update
    void Start()
    {
        UpdateLastCubeObject();
    }
}
