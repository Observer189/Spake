using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInputInfo//класс - информация о пользовательском вводе относительно движения корабля
{
    private sbyte turnInfo;//в каккую сторону поворачиваться
                          //1-вправо
                          //-1-влево
                          //0-не поворачиваться
    private sbyte gasInfo;//в какую сторону направлен газ
                         //1-вперед
                         //-1-назад
                         //0-нет газа
    private bool isShooting;//стреляет корабль или нет

    public sbyte getTurnInfo()
    {
        return turnInfo;
    }
    public sbyte getGasInfo()
    {
        return gasInfo;
    }
    public bool getIsShooting()
    {
        return isShooting;
    }

    public void setTurnInfo(sbyte i)
    {
        turnInfo = i;
    }
    public void setGasInfo(sbyte i)
    {
        gasInfo = i;
    }
    public void setIsShooting(bool i)
    {
        isShooting = i;
    }
}
