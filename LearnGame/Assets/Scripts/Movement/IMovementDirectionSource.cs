using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LearnGame
{
    public interface IMovementDirectionSource
    {
        Vector3 MovementDirection { get; }
    }
}