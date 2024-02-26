using ImageMagick;
using LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections;
using System.Collections.Frozen;
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

        public async Task<MagickColor> ExtractDominantColor(string imageUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(imageUrl);
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var image = new MagickImage(stream))
                    {
                        image.Scale(100, 100); // Skalierung für Performance

                        var settings = new QuantizeSettings
                        {
                            Colors = 10 // Anzahl der zu extrahierenden Farben erhöht
                        };
                        image.Quantize(settings);

                        var histogram = image.Histogram();
                        var dominantColor = histogram
                            .OrderByDescending(kvp => kvp.Value)
                            .Select(kvp => ConvertToMagickColor(kvp.Key))
                            .FirstOrDefault();
                        //.FirstOrDefault(c => !IsColorCloseToWhite(c)); // Ignoriere helle Farben

                        return dominantColor ?? MagickColors.Black; // Rückgabe Schwarz, wenn keine geeignete Farbe gefunden wurde
                    }
                }
            }
        }

        public MagickColor ConvertToMagickColor(IMagickColor<ushort> color)
        {
            return new MagickColor(color.R, color.G, color.B);
        }

        private bool IsColorCloseToWhite(MagickColor color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double lightness = (max + min) / 2.0;

            return lightness > 0.9; // Schwellenwert kann angepasst werden
        }




        public async Task<List<long>> FindSimilarColors(string selectedColorHex, double threshold)
        {
            var selectedColor = new MagickColor(selectedColorHex);
            var allColors = await _unitOfWork!.ProductColor.GetAllAsync();
            var similarProductIds = new List<long>();

            foreach (var color in allColors)
            {
                var colorToCompare = new MagickColor(color.ColorHex!);
                if (CalculateColorDistance(selectedColor, colorToCompare) <= threshold)
                {
                    similarProductIds.Add(color.ProductId);
                }
            }

            return similarProductIds.Distinct().ToList();
        }


        public double CalculateColorDistance(MagickColor color1, MagickColor color2)
        {
            // Berechne die Differenzen der RGB-Komponenten und normalisiere sie auf den Bereich von 0 bis 255.
            double rDiff = (color1.R - color2.R) / 257.0; // 65535 / 257 = 255
            double gDiff = (color1.G - color2.G) / 257.0;
            double bDiff = (color1.B - color2.B) / 257.0;

            // Berechne die euklidische Distanz zwischen den beiden Farben.
            return Math.Sqrt(rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
        }




    }
}
