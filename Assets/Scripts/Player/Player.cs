using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : InGameStepObject
{
    public BowController bowController;
    public UnitBoard unitBoard;
    public Hpbar hpBar;
    public ArrowSpawner arrowSpawner;


    protected override void Awake()
    {
        unitBoard.Setup();
    }

}
