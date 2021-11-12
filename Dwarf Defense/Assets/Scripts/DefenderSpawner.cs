using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";

    GameObject defenderParent;

    Defender defender;
    public float xFixUp = 0.5f;
    public float xFixDown = 0.5f;
    public float yFixUp = 0.8f;
    public float yFixDown = 0.2f;

    public void Start()
    {
        CreateDefenderParent();
    }

    public void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() // Will run if the left mouse click was pressed on the gameObject this script is attached to
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect; // Makes the defender member equal to the defender passed in the function (Used in DefenderButton.cs)
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var resourceDisplay = FindObjectOfType<ResourceDisplay>();
        int defenderCost = defender.getResourceCost();
        if (resourceDisplay.HaveEnoughResources(defenderCost))
        {
            SpawnDefender(gridPos);
            resourceDisplay.SpendResources(defenderCost);
        }
    }

    private Vector2 GetSquareClicked() // Method to get the mouse's position when clicked
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // A Vector2 variable at the mouse's specific x and y pos
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); // wherever the mouse is clicking on the screen convert to a world point
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        // Debug.Log("Raw Pos: " + rawWorldPos);

        float newX = Mathf.RoundToInt(rawWorldPos.x); // a float that stores a rounded raw coordinate on the X axis
        float newY = Mathf.RoundToInt(rawWorldPos.y); // a float that stores a rounded raw coordinate on the Y axis

        // Debug.Log("Rounded Pos: (" + newX + ", " + newY + ")");

        if ((rawWorldPos.x - newX) > 0.0f)
        {
            newX = newX + xFixUp;
        }
        else if ((rawWorldPos.x - newX) <= 0.0f)
        {
            newX = newX - xFixDown;
        }

        if ((rawWorldPos.y - newY) > 0.0f)
        {
            newY = newY + yFixUp;
        }
        else if ((rawWorldPos.y - newY) <= 0.0f)
        {
            newY = newY - yFixDown;
        }

        // Debug.Log("Fixed Pos: (" + newX + ", " + newY + ")");
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 mousePos)
    {
        Defender newDefender = Instantiate(defender, mousePos, Quaternion.identity) as Defender; // Instantiates a new defender at a given position and rotation
        newDefender.transform.parent = defenderParent.transform;
    }                                                                                                // Quarternion just means no rotation at all thanks!
}                                                                                                    // as GameObject just means we can see this and manipulate
                                                                                                        // it in the heierarchy
                                                                                                     // We added a Vector2 as an argument so we can get the mouse's position