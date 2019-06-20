using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class BattleInputInfo//класс - информация о пользовательском вводе относительно движения корабля
{
    /// <summary>
    /// В какую сторону поворачиваться
    /// <value>
    ///    1 - вправо
    ///    -1 - влево
    ///    0 - не поворачиваться
    /// </value>
    /// </summary>
    private sbyte turnInfo;
    
    /// <summary>
    /// На какой угол надо повернуться
    /// </summary>
    private float angle;
    
    /// <summary>
    /// В какую сторону направлен газ
    /// <value>
    ///    1 - вперед
    ///    -1 - назад
    ///    0 - нет газа
    /// </value>
    /// </summary>
    private sbyte gasInfo;
    
    /// <summary>
    /// Стреляет корабль или нет
    /// </summary>
    private bool isShooting;

    public float Angle
    {
        get => angle;
        set => angle = value;
    }

    public bool IsShooting
    {
        get => isShooting;
        set => isShooting = value;
    }

    public sbyte TurnInfo
    {
        get => turnInfo;
        set => turnInfo = value;
    }

    public sbyte GasInfo
    {
        get => gasInfo;
        set => gasInfo = value;
    }

}
