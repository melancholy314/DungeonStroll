using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public virtual void RecieveDamage() //получение урона
    {
        Die();
    }

    protected virtual void Die() //уничтожение существа
    {
        Destroy(gameObject);
    }
}
