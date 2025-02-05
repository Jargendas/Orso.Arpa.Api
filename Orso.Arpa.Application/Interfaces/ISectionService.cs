using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orso.Arpa.Application.SectionApplication;
using Orso.Arpa.Application.SelectValueApplication;

namespace Orso.Arpa.Application.Interfaces
{
    public interface ISectionService
    {
        Task<SectionTreeDto> GetTreeAsync(int? maxLevel);

        Task<IEnumerable<SectionDto>> GetAsync(bool instrumentsWithChildrenOnly);
        Task<IEnumerable<SectionDto>> GetDoublingInstrumentsAsync(Guid id);
        Task<IEnumerable<SelectValueDto>> GetPositionsAsync(Guid id);
    }
}
