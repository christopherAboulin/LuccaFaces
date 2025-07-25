using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LuccaFaces
{
    public class Service
    {
        public static readonly Dictionary<string, string> ImgHashToNames;

        static Service()
        {
            ImgHashToNames = new Dictionary<string, string>
            {
                ["0a90657bbec21e57f79ccb05a80f2d7a624e488efea41796801b9618b918480e"] = " Véronique **** ",
            ["0ce549e5a75bc23a29d90578cd74392513c5535362fb3373a545165cb793607e"] = " Donatien **** ",
            ["1d15f1a255a0982f61587e47f1091589bc32c67f2546d106ab94639036a338ce"] = " Florian **** ",
                // Ajoutez le reste selon votre table complète
            };
        }

        public static async Task<string> ComputeSHA256HashAsync(Stream imageStream)
        {
            using var sha256 = SHA256.Create();
            var hashBytes = await sha256.ComputeHashAsync(imageStream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
        public static async Task<string> GetImageHashAsync(HttpClient client, string imageUrl)
        {
            // URL complète de l’image
            string fullImageUrl = "https://tdi-group.ilucca.net" + imageUrl;

            // Crée une requête avec l’en-tête Cookie uniquement pour cette requête
            using var request = new HttpRequestMessage(HttpMethod.Get, fullImageUrl);

            // Exécute la requête et obtient directement le flux de réponse
            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            // Lecture du flux et calcul de hachage
            await using var stream = await response.Content.ReadAsStreamAsync();
            return await ComputeSHA256HashAsync(stream);
        }

    }
}
