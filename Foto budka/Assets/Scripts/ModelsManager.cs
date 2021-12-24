using UnityEngine;

public class ModelsManager : MonoBehaviour
{
    public UnityEngine.Object[] models;

    int indexOfSelectedModel = 0;

    GameObject currentSelectedModel;

    void Start()
    {
        models = Resources.LoadAll("Input", typeof(GameObject));

        currentSelectedModel = (GameObject)Instantiate(models[indexOfSelectedModel], transform);
    }

    public void NextModel()
    {
        Destroy(currentSelectedModel);
        
        indexOfSelectedModel++;

        if(indexOfSelectedModel == models.Length)
        {
            indexOfSelectedModel = 0;
        }

        currentSelectedModel = (GameObject)Instantiate(models[indexOfSelectedModel], transform);
    }

    public void PreviousModel()
    {
        Destroy(currentSelectedModel);

        indexOfSelectedModel--;

        if (indexOfSelectedModel == -1)
        {
            indexOfSelectedModel = models.Length-1 ;
        }

        currentSelectedModel = (GameObject)Instantiate(models[indexOfSelectedModel], transform);
    }

}
