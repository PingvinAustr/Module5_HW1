using System.Collections.Generic;

namespace Module5_HW1.Models;

public class Collection<T> : Validation
{
    public IReadOnlyCollection<T>? Data { get; init; }
}