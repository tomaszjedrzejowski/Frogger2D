using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesLeftVisualisation : MonoBehaviour
{
    [SerializeField] Transform lifeImagePrefab;
    private int _lifeAmoutn;
    private List<Transform> imageList = new List<Transform>();

    void Start()
    {        
        for (int i = 0; i < _lifeAmoutn; i++)
        {
            Transform lifeImage = Instantiate(lifeImagePrefab, this.gameObject.transform );
            imageList.Add(lifeImage);
        }
    }

    public void UpdateLifeAmount(int lifeAmount)
    {
        _lifeAmoutn = lifeAmount;
        foreach (var image in imageList)
        {
            if (imageList.IndexOf(image) + 1 > _lifeAmoutn) image.gameObject.SetActive(false);
            else image.gameObject.SetActive(true);
        }
    }
}
