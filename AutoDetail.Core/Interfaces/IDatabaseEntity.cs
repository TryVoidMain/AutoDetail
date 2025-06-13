﻿namespace AutoDetail.Core.Interfaces
{
    public interface IDatabaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
