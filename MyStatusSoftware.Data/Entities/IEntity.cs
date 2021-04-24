using System;

namespace MyStatusSoftware.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreationDate { get; set; }

        int CreationUser { get; set; }

        bool IsEnable { get; set; }

        DateTime? UpdateDate { get; set; }

        int? UpdateUser { get; set; }

        DateTime DateOrdering { get; set; }

    }
}
