using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer : MonoBehaviour
{
    public int changeAmount;
    public bool destroyAfterCollsion;
    public enum ChangeType {Health, Score, Seed};
    public ChangeType changeType;


}
