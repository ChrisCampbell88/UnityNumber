using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text NumberValue;
    public Text SpeedValue;
    public Button UpgradeButton;
    public Text   UpgradeButtonText;
    public float  UpgradeBaseCost;
    public float  UpgradeCostMultiplier;
    public float  UpgradeBaseValue;
    public float  UpgradeValueMultiplier;
    public float StartSpeed;

    private float Number = 0;
    private float Speed;

    private float UpgradeCost;
    private float UpgradeValue;
    private int   UpgradeCount = 0;

	// Use this for initialization
	void Start () {
        this.Speed = this.StartSpeed;

        this.SpeedValue.text = this.Speed.ToString();

        this.UpgradeCost = this.UpgradeBaseCost;

        this.UpgradeValue = this.UpgradeBaseValue;

        this.UpgradeButtonText.text = this.UpgradeCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        // Update the number every frame
        UpdateNumber();

        // Update the disabled state of the upgrade button
        this.UpgradeButton.interactable = (this.Number >= this.UpgradeCost ? true : false);
    }

    void UpdateNumber()
    {
        // Calculate the new number value
        this.Number += Time.deltaTime * this.Speed;

        // Update the number text
        this.NumberValue.text = this.Number.ToString("0.00");
    }

    public void UpgradeSpeed()
    {
        // Subtract the cost of the upgrade from the number
        this.Number -= this.UpgradeCost;

        // Update the number text
        this.NumberValue.text = this.Number.ToString("0.00");

        // Calculate the new value of the upgrade
        this.Speed = (float)(this.UpgradeBaseValue * Math.Pow(this.UpgradeValueMultiplier, this.UpgradeCount));

        // Update the speed text
        this.SpeedValue.text = this.Speed.ToString("0.00");

        // Calculate the price for the next upgrade
        this.UpgradeCost = (float)(this.UpgradeBaseCost * Math.Pow(this.UpgradeCostMultiplier, this.UpgradeCount));

        // Increase the upgrade count
        this.UpgradeCount++;

        // Update the text in the upgrade button to show the new cost
        this.UpgradeButtonText.text = this.UpgradeCost.ToString("0.00");
    }
}
