﻿using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {
    [SerializeField]
    private GameObject cardBack;
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private SceneController controller;

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void SetCard(int id,Sprite image)
    {
        _id = id;
		GetComponent<SpriteRenderer>().sprite = image;
    }

    public void CardClicked()
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.cardRevealed(this);
        }
        Debug.Log("Mouse Click");
    }

    void OnMouseDown()
    {
        if(cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
			controller.cardRevealed(this);
        }
        Debug.Log("Mouse Click");
    }

	public void Unreveal()
	{
		cardBack.SetActive (true);
	}
}
