using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Services
{
    /// <summary>
    /// Frontend tarafından gelen bir isteğin işlenip frontend tarafına bir sonuç döndürmek için yaptık. Burada API de InputModel ve ViewModel yerine artık DTO(Data Transfer Object) terimini kullanacağız. Application katmanı için yazıyoruz.
    /// </summary>
    /// <typeparam name="TRequestDto">Inputmodel</typeparam>
    /// <typeparam name="TResultDto">ViewModel</typeparam>
    public interface IApplicationService<TRequestDto,TResultDto>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<TResultDto> HandleAsync(TRequestDto dto);
    }
}
