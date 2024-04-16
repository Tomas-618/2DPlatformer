using System;

public interface IReadOnlyHealthEvents
{
    event Action Died;

    event Action<float> Damaged;

    event Action<float> OnHealing;
}
