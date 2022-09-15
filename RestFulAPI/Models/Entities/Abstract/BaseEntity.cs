using System;

namespace RestFulAPI.Models.Entities.Abstract
{
    public enum Status { Active = 1, Modified, Passive }
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get => __createDate; set => __createDate = value; }

        private DateTime __createDate = DateTime.Now;

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get => _status; set => _status = value; }

        private Status _status = Status.Active;
    }
}
