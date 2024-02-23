using ImageMagick;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces
{
    public interface IColorAnalysisService
    {
        Task<List<MagickColor>> ExtractDominantColors(string imageUrl);
    }
}
