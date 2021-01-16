using MassTransit;
using System;

namespace ToDo.Infra.Core
{
    public static class GuidGenerator
    {
        public static Guid Generate => new Guid(NewId.Next().ToString("D").ToUpperInvariant());
    }
}