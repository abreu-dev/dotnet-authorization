namespace Autho.Infra.Data.Entities.Base
{
    public abstract class BaseData
    {
        public Guid Id { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; }

        public DateTime? UpdatedDate { get; private set; }
        public string? UpdatedBy { get; private set; }
    }
}
