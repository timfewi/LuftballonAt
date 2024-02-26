using ImageMagick;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces
{
    public interface IColorAnalysisService
    {
        Task<MagickColor> ExtractDominantColor(string imageUrl);
        Task<List<long>> FindSimilarColors(string selectedColorHex, double threshold);
        double CalculateColorDistance(MagickColor color1, MagickColor color2);
        MagickColor ConvertToMagickColor(IMagickColor<ushort> color);

    }
}
