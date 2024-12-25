using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public GameObject character; // Character object (make sure it has a Renderer component)
    public Button greenButton;
    public Button redButton;
    public Button purpleButton;
    public Button blueButton;
    public Button blackButton;
    public Button cyanButton;
    public Button varsayilan; // Default (White) button
    public Skill skill; // Reference to the Skill script

    private void Start()
    {
        // Load previously saved color when the game starts
        LoadColor();

        // Check if the skill is unlocked and update button interactivity
        UpdateButtonInteractivity();

        // Add listeners to buttons to change character color
        greenButton.onClick.AddListener(() => ChangeColor(Color.green));
        redButton.onClick.AddListener(() => ChangeColor(Color.red));
        purpleButton.onClick.AddListener(() => ChangeColor(Color.magenta));
        blueButton.onClick.AddListener(() => ChangeColor(Color.blue));
        blackButton.onClick.AddListener(() => ChangeColor(Color.black));
        cyanButton.onClick.AddListener(() => ChangeColor(Color.cyan));
        varsayilan.onClick.AddListener(() => ChangeColor(Color.white));
    }

    // Function to change character color
    private void ChangeColor(Color color)
    {
        // Change the character's color
        character.GetComponent<SpriteRenderer>().color = color;

        // Save the selected color to PlayerPrefs
        if (color == Color.green)
        {
            PlayerPrefs.SetString("SelectedColor", "Green");
        }
        else if (color == Color.red)
        {
            PlayerPrefs.SetString("SelectedColor", "Red");
        }
        else if (color == Color.magenta)
        {
            PlayerPrefs.SetString("SelectedColor", "Purple");
        }
        else if (color == Color.blue)
        {
            PlayerPrefs.SetString("SelectedColor", "Blue");
        }
        else if (color == Color.black)
        {
            PlayerPrefs.SetString("SelectedColor", "Black");
        }
        else if (color == Color.cyan)
        {
            PlayerPrefs.SetString("SelectedColor", "Cyan");
        }
        else if (color == Color.white)
        {
            PlayerPrefs.SetString("SelectedColor", "White");
        }

        // Save PlayerPrefs
        PlayerPrefs.Save();
    }

    // Function to load the saved color when the game starts
    private void LoadColor()
    {
        // Get the saved color from PlayerPrefs (default is "White")
        string selectedColor = PlayerPrefs.GetString("SelectedColor", "White");

        // Set the character's color based on the saved value
        switch (selectedColor)
        {
            case "Red":
                character.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "Purple":
                character.GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case "Blue":
                character.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case "Black":
                character.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "Cyan":
                character.GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            case "Green":
                character.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            default:
                character.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }

    // Function to update button interactivity based on skill's unlock status
    private void UpdateButtonInteractivity()
    {
        if (skill != null && !skill.isUnlocked)
        {
            // If the skill is not unlocked, disable the color buttons and set default (white)
            greenButton.interactable = false;
            redButton.interactable = false;
            purpleButton.interactable = false;
            blueButton.interactable = false;
            blackButton.interactable = false;
            cyanButton.interactable = false;
            varsayilan.interactable = true; // Default button should still be clickable to reset to white

            // Set the character color to white (default)
            character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            // If the skill is unlocked, enable all color buttons
            greenButton.interactable = true;
            redButton.interactable = true;
            purpleButton.interactable = true;
            blueButton.interactable = true;
            blackButton.interactable = true;
            cyanButton.interactable = true;
            varsayilan.interactable = true; // Allow resetting to white

            // If the skill is unlocked, we don't need to change the color
            // But we keep the color the user has selected earlier.
        }
    }
}
