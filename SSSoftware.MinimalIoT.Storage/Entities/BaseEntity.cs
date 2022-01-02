﻿namespace SSSoftware.MinimalIoT.Storage.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}