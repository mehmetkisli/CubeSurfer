using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroStackController : MonoBehaviour
{

    public List<GameObject> cubeList = new List<GameObject>();

    public GameObject lastCubeObject; // should be pirvates



    private void UpdateLastCubeObject(){
        if(cubeList.Count == 0){
           GameOverController.Instance.FailedChapter();
        }
        lastCubeObject = cubeList[cubeList.Count-1];
    }

    public void IncreaseCubeStack(GameObject _gameObject){
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastCubeObject.transform.position.x, lastCubeObject.transform.position.y -2f, lastCubeObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        cubeList.Add(_gameObject);
        UpdateLastCubeObject();
    }
    public void DecreaseCubeStack(GameObject _gameObject){
        _gameObject.transform.parent = null;
        cubeList.Remove(_gameObject);
        UpdateLastCubeObject();

    }

    public void DestroyLastCube(GameObject _gameObject){
        cubeList.Remove(_gameObject);
        Destroy(_gameObject);
        UpdateLastCubeObject();
        
    }
    



    // Start is called before the first frame update
    void Start()
    {
        UpdateLastCubeObject();
    }
}
