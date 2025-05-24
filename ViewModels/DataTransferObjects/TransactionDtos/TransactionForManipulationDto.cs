using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.TransactionDtos
{
    public record TransactionForManipulationDto(Guid bookId, DateTime borrowDate);
}
