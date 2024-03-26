using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBC.DTO
{
    public class IndividualRelations
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public Type RelationType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public Individual FromIndividual { get; set; } = null!;
        public Individual ToIndividual { get; set; } = null!;
    }
    public enum Type : byte
    {
        Relative = 0,
        Friend =1,
        Colleague =2,
    }
}
