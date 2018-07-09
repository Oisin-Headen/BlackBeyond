﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is dedicated to creating links between the View, Controller and Model
// TODO might be better as a static class with static methods
public class ModelLink
{

    public GameController GameController { get; private set; }
    public Transform MapContainer { get; private set; }

    public ModelLink(GameController gameController, GameObject mapGameObject)
    {
        this.GameController = gameController;
        this.MapContainer = mapGameObject.transform;
    }

    // Creates the view and gets the controller for a Space
    public void CreateSpaceView(SpaceModel spaceModel)
    {
        // Creates the space GameObject in the correct position. TODO update this formula for hexes
        GameObject spaceView = Object.Instantiate(GameController.GetSpaceView(), 
                                                  new Vector2((float)spaceModel.Column * 0.6f, (0 - spaceModel.Row * 1.04f)), Quaternion.identity, MapContainer);
        // Gets the controller from the GameObject.
        SpaceController spaceController = spaceView.GetComponent<SpaceController>();
        // Lets the Controller access the GameObject
        spaceController.SetSpaceView(spaceView);
        // Lets the Controller access the Model
        spaceController.SetSpace(spaceModel);
        // Lets the Model access the Controller, as a callback
        spaceModel.SetController(spaceController);
    }

    // Creates a Nebula space.
    public void CreateNebulaSpace(NebulaSpaceModel nebulaSpaceModel)
    {
        CreateSpaceView(nebulaSpaceModel);
        Object.Instantiate(GameController.GetNebula(),
                           nebulaSpaceModel.GetController().GetPosition(), Quaternion.identity, MapContainer);
        nebulaSpaceModel.GetController().SetNebula();
    }

    // Same as above for a Space GameObject
    public void CreatePlayerView(PlayerModel playerName)
    {
        // Creates the player GameObject in the correct position. TODO update this formula for hexes
        GameObject playerView = Object.Instantiate(GameController.GetPlayerView(),
                                                   playerName.GetSpace().GetController().GetPosition(), Quaternion.identity);
        // Sets the camera following the player
        Camera.main.transform.parent = playerView.transform;
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);

        // Gets the controller from the GameObject.
        PlayerController playerController = playerView.GetComponent<PlayerController>();
        // Lets the Controller access the GameObject
        playerController.SetShipView(playerView);
        // Lets the Controller access the Model
        playerController.SetModel(playerName);
        // Lets the Model access the Controller, as a callback
        playerName.SetController(playerController);
    }

    // Same as above for a Space GameObject
    public void CreatePirateView(PirateModel pirateModel)
    {
        // Creates the player GameObject in the correct position. TODO update this formula for hexes
        GameObject pirateView = Object.Instantiate(GameController.GetPirateView(),
                                                   pirateModel.GetSpace().GetController().GetPosition(), Quaternion.identity, MapContainer);

        // Gets the controller from the GameObject.
        PirateController pirateController = pirateView.GetComponent<PirateController>();
        // Lets the Controller access the GameObject
        pirateController.SetShipView(pirateView);
        // Lets the Controller access the Model
        pirateController.SetModel(pirateModel);
        // Lets the Model access the Controller, as a callback
        pirateModel.SetController(pirateController);
    }
}
