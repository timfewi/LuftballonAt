using ImageMagick;
using LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations.UtilityServices
{
    public class ColorAnalysisService : BaseService, IColorAnalysisService
    {
        private readonly HttpClient _httpClient;
        public ColorAnalysisService(IServiceProvider serviceProvider, HttpClient httpClient) : base(serviceProvider)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MagickColor>> ExtractDominantColors(string imageUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(imageUrl);
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var image = new MagickImage(stream))
                    {
                        image.Scale(100, 100); // Skalierung für performance

                        var settings = new QuantizeSettings
                        {
                            Colors = 5 // Anzahl der zu extrahierenden Farben
                        };
                        image.Quantize(settings);

                        var histogram = image.Histogram();
                        var dominantColors = histogram.OrderByDescending(kvp => kvp.Value)
                                                            .Take(5)
                                                            .Select(kvp => new MagickColor(kvp.Key))
                                                            .ToList();
                        return dominantColors;
                    }
                }
            }
        }




    }
}
