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
                ["0a90657bbec21e57f79ccb05a80f2d7a624e488efea41796801b9618b918480e"] = " Véronique Vallier-Prieur ",
            ["0ce549e5a75bc23a29d90578cd74392513c5535362fb3373a545165cb793607e"] = " Donatien Cognard ",
            ["1d15f1a255a0982f61587e47f1091589bc32c67f2546d106ab94639036a338ce"] = " Florian Carle ",
            ["2bddeb66a590c78f331305a91249c8aa6040165f0a4541863ca595f2844b55e0"] = " Matthieu Desbenoit ",
            ["2c38d59fd187f26c8b26f9cd2214d0b0d42a2370e6bd7aca7b6c7e5608a5a6d7"] = " Nathalie Lepage ",
            ["3b29cdf605d5aea84937361b11ca2ce29f090d49bf97730f8ec985ad3e4d27c5"] = " Yassin Akdim ",
            ["4f963a892e318b9ac5c7115c49f78a2ef8c45b54c6a95d69b4c4c07fd44c9353"] = " Edmundo Brito Aubry ",
            ["05a599936de4be720f156e586da9aa51b7a1e13addebb9003e8df66ba74fd472"] = " Fardeen Omar ",
            ["5e85bceacfb5595dd5117670318702aa3ed058ff8b75d3da038a8e06b9a733ea"] = " Anna Massignan ",
            ["5eeacbe975a4dd4f726fc81e33c59528ceb81a6f400caf60b882f546c722c7ec"] = " Jéremy Casseville ",
            ["06d2fda803c337148b5d82180465ff18cb593868cb64314cde0a8b4772d6364b"] = " Sophie Ung ",
            ["7de2454a192380980cb9769b3017c17045b34c5e616b2c986ac2ea26a935613b"] = " Olivier Jammet ",
            ["7fbcfb718f580573ff071ead3c850c056578d803b6f6a8bee4e3e7e494579c52"] = " Nasrine Daira ",
            ["8b883f87e485bc7881837956decad222fbab31df6cad164bfb5a44ef1473c8a3"] = " Amandine Dalmais ",
            ["8e638fbb7fe44f154f017795d036262df08839c45561e708ed55e654f6d368e2"] = " Ouadia Ben Khalifa ",
            ["9b4752095f3a04ee86fc4a1a7a8cb814b82cbf01b49546c595200914d6aca0fe"] = " Olivier Maleval ",
            ["9b630216139132f0865d487c7151aa27d3e829875f4e2534c7796e1203218f7c"] = " David Martinez ",
            ["9e1a345e4f6b6c60888493e37884dbca71bd34c93170bf356a61fc868bc37bd8"] = " Frédérick Lab ",
            ["22c8d5c7c82cfacb575f77072b02a215c6a10bb799590ae2c2561570f0d0dec5"] = " Yohan Caschera ",
            ["22de1dc440e73b265101ff8b34362b2ff9a3bd691768e1887d804c7665c1388f"] = " Marta Wojcik ",
            ["26be8becea81c82bd178149605466e183bf2541ec32fcb27309c9bac12deb101"] = " Maroussia Lecomte ",
            ["45c5720817b5fb08cf04fd9abfdf69ebe1d8d12a2ed2e76c73c4fdd194b91177"] = " Julien Pilloud ",
            ["46c7fb4e0119f0547818393e10e852286b0c96a8a394781d23c9a2b11863aa5d"] = " Tomy Nguyen ",
            ["47e5a9cefb122f15498cfcc77265191aaf65c7204d2a66e66f35b483c0c715c3"] = " Claudia Cimmarusti ",
            ["63bd0d6846fe9067a4d74f17c6c2183b146c7c3c9dbc985fe5c877c57b48eab8"] = " Victor Florent ",
            ["65effb4cce7794290ad50f92f9edc022946948c3179c24409a19ab06e14c72a2"] = " Tévy Proum ",
            ["81fcc9918dd401e2409e249abd04cc658afb3ea12c12c564138005ef5bac33a3"] = " Alexandra Chabriel ",
            ["85bdd5f0397079b90f5cef130503acfd7f129fc84b45cf9199520415cd4d402c"] = " Isabela Iftime ",
            ["92a0b5c3afb6704d0dc9b9ef088f2be765d159df4c3e88a6b68ad0c05fb95bce"] = " Michaël Devers ",
            ["93ed4d75d0fab749248177700c9d529f899818b5f41325be3827388e3e993923"] = " Mario Sa ",
            ["96a867ca3256debf96e1649b0586992027de79e1b36081cfb1ee59037e1b6fbb"] = " Julien Jung ",
            ["98e8097296f9d4f93b87cec891a4277e94b5a63493e62f101b12aa5965a2125f"] = " Aurélie Sanchez ",
            ["102ae895eb5f91c420ff01b422b505e88faf8a36108a3e9194769efb8e04a9e6"] = " Clément Courtembert-Gaillard ",
            ["397c5e5c7f93ec9909dee71d952ef5239a1afda16a7515f4f1e4b49ff0917e09"] = " Grégory Trabarel ",
            ["544fe0d02a250e811313d00da8cd8890d20a824ba32b9b3175830f894adbf40a"] = " Hugo Eymann ",
            ["593c3ebf9581cd52d77bf31c1ca374a656daa6a98ee5d76d19ae88f81f78582a"] = " Rodolphe Berthet ",
            ["872fe45e373a53d9f7d747a91d1dd9e7892011a7a1bd41e6e8099651f5d1913f"] = " Julien Le Gall ",
            ["2311f51365e80b5ad50a0af29ac176f30164688b17bc4de21e7496f758d6e607"] = " Eric Yang ",
            ["3182d3cc9ee65461324e4abb57f3129bf22834375472d0160990fde9977bba15"] = " Lara Grinand ",
            ["3566ff6be7ba0dfd4dadc62a57a292befe02d486d78c4d31b9c22a8094513f14"] = " Camille Meffre ",
            ["6389ae3e44f78b64c778759b9eb1a0c45bb77a93c13a03985922b997d950540a"] = " Gloria Lupaka ",
            ["9132c26d75401e2a1002c39d28b34e1ebe480ae623f451532fc079eb4612b79a"] = " Romain Maragou ",
            ["33879fafb986d11efdbdd45669e36e85d050f49305331570c0b94d78ff73cb92"] = " Matteo Moretto ",
            ["42158af544320244dd338880c09318f2ace48d9dad781e6ae25944507d95174f"] = " Nathanaël Joncheray ",
            ["91046ae7ee42babd3f8be3aec8283da822c36a590e51460c0f860bf321bb73ef"] = " Isabella Sofia Hernandez Beltran ",
            ["97224e3ed25929d1f3be8d604f198151e556675bda4db937cb6604837c02d384"] = " Cyril Jacquard ",
            ["099642b858e38a9d145b6d4265c4d5e5b7476414b4d4090ff27fa31b3fd61a34"] = " Martin Louc ",
            ["154430f0560f2a648455ef02fcddc55beda1e4f195b140c33912d5197036ac84"] = " Sylvie Callet ",
            ["468297dad587052e57a45970a9286c9fc0716c6d499f3feaf14d79f6c4caeac1"] = " Amandine Johais ",
            ["707387eced0db32720734bc2f9fc3ced63a1d8ccc7729a6d5bbbfe5e4a38795c"] = " Jean-Louis Tran ",
            ["2090337dbd950970dc864b8b969100716ab49da3304755c4e9290869ee8f12ca"] = " Lucas Larobe ",
            ["03057706a26a10052c54b9a2719b27101c12b8023e2655e62ece89a95c35e9b7"] = " Nathan Charlet ",
            ["a87c1f7ea73eb9226fd96366637567633880a393ac0b6c24c4bd1f73a363bec3"] = " Armance Rodot ",
            ["aaf60806e7612875336295f3b0905ed2f31230ecab0e9be87d63726a62a96cf6"] = " Kloé De Oliveira Paiva ",
            ["ab84f8d6f6aff6e36314bba79cfbd5819b9d011de2e4e4295d3fc5df0369d596"] = " Maureen Farny ",
            ["aff7e1676950d647e9b5e05e551d66ea136a11ef5d4f10760e033fc392516514"] = " William Simon ",
            ["b4d7c47f24221da82417e55087aeef164b86e766946e4513ebad0c032cf25d7b"] = " Clément Couval ",
            ["bb3ed501c506db6d90b38e8751ff688b6c2c00cfbcff2b878f2ae2d66e25a821"] = " Laurent Mazard ",
            ["bd51d0367a6966dc4712104fbd40a04839ec30b0f320ac1ea2749dc2f0d02ae4"] = " Guillaume Patinaud ",
            ["bdfb6c074ceea174ad86e50d61e2f73c8132e388cf97050bf111fe19ba852394"] = " Fatima Nedjari ",
            ["c2b0479395f4d9a9bfdddcdb5452532cddd716f25eaf0ad21988888d1f38004a"] = " Meriem Said ",
            ["c776a1ca83ca06eb7a06f2ed233214258265f9104c172a57fe38cbc9118f548c"] = " Gustavo Antonio Reyes Romero ",
            ["ccda9e0a8dc4eee91e51a8a907334112c567cbb7d633959db9fa25b510e08777"] = " Guillaume Floquet ",
            ["cdfd0162c243a9c2856a010083ac9d347108d53ecd60506b6f8b7092325a58dc"] = " Louis Servanin ",
            ["ce19c6acdd0a0cba4cfd5971ed645daf169b417fd0b22544fe51edcd3aaaafc2"] = " Louis Cournollet Rodriguez ",
            ["d9c3b5b0de93524df453d922c4ed4b74008aa6f5df00d054ccb956d651afb396"] = " Cédric Chambon ",
            ["d16baba8fe44d46bac370432e25d861671ab11fa67b0eb5e74fae83230686920"] = " Wilfried Morel ",
            ["d25c868f616e281a845a876e05d66d7c7056570b291b89c91ae20eb2e7845dd8"] = " Loric Breton ",
            ["d25e5a5b588606b4124b37e8b45b5ce7c2514b84449efe12fc74cacba0a98a1e"] = " Carla Costa ",
            ["d1206e56133f88b16a7c6834a06ad12000c22c0f15b6ee20e4482091e664b33b"] = " Abbas Terhini ",
            ["d566835788cba9a50df27a3bd214b09a23bbba147259878b95d523a966d47ba1"] = " Julien Martin ",
            ["da61dc1810da2663acf41f90550dbc82e9577712e39d7b19c8c7ef6e6cd3ee9b"] = " Jordan Giacomarra ",
            ["dc04bbddd7502ffcda8f7ec45705e8eabd5b39e1b7ab26f92a457ba2a67a4ac3"] = " Quentin Roy ",
            ["dd9545bc2162776e8d9ad58088dad2e3304f9a134a9946bbd61220f6160a2e74"] = " Agnès Limousin ",
            ["de4ff8563df184de0cf9331fab36b64ac9414e32394a6a786d991f34584a3cba"] = " Aurélie Caubet ",
            ["e1e8b03b3d29de77533d1bc42cad88d838d5103ccfe333063cbcd915fb2ec1f8"] = " Emma Collon ",
            ["e8bc668e4f4b197f5e0e0f6b57f27949c418634aec19ab4382f8ca0f7c74d50d"] = " Xavier Perrot ",
            ["e9c6396cbd3619e3754cac8c17e2d2562b6fd6aa8e3497ee89b6fb3efaa648f9"] = " Paul Houssaye ",
            ["ed3f94e7f2f345a63da30d6a8f9e2f727068e8bf80d1a416430ff0e0e4a5bf80"] = " Vincent Briottet ",
            ["ef0a12c62e8f15a0c0a9b0ac9bd2fb6ecdc41c83eec735845f1f7f97883692f5"] = " Alexandre Curt ",
            ["f4a8cab1504c9ec895d8789c0d9e57845b33214fa16c489869891f50fb8ad8e2"] = " Stéphane Djongo Homsi ",
            ["f9ab83b2314e239281314a40f0630edd92c3c04c06ad7e1d817310e851266b3c"] = " Morgane Parizot ",
            ["f134b03921e5979a3a34a8c4c60217f54ba8cb890d1fc9e03cea9e569cf6251f"] = " Jeffrey Fevre ",
            ["f5102ee64b1d6715756b406f864030c53ace2a5e30c2bf95e6a83e2330afb484"] = " Nadia Auclair ",
            ["faf0f50d954b099f67be8f32a84a39b19ecff037865f0753dd9f3d93782afea7"] = " Johanna Sevenier ",
            ["faf91b237fb23f3bd991f54ddb32c583333efced9f4f0b2ea7cba8e8a91b8bd0"] = " Claire Jardon ",
            ["ff46079f8f12a3b0c868f451a5dd7d1bf53463cd26389d004ca99c0a8bef3f16"] = " Julien Afarian ",
            ["7b710acff22adc94aec312a51e24d2b6fac2b321c9c878a47520e9c9799f56da"] = " Thierry Aing ",
            ["7087eec2e6d0a4e24383c36a4560bceaf42eefe940914c67a96d49a0def6c876"] = " Lionel Gris ",
            ["80142e1e9427568f597fd0c7a23e26e85da65903695d2fd31a82f6d629c72f93"] = " Didier Guichard ",
            ["c351e97bb865e46400d52f19cacb12e32cc5c25f8aa526f6320c0277aad4c63c"] = " Alexandre Combes ",
            ["a4bb296f99acbc1253c4b2ae96db15ed6b38aa165c5d5c6bede2d06c7d392e23"] = " Madjid Benmelouk ",
            ["1d015b39b09fea2961c3c23237323c7e4c6d24a1f30121aeb0d699d12af825ad"] = " Cindy Bonnardel ",
            ["c55b329fd3cabab3688c38e884560384a0c4ee190a5bbf0e6009ef9b053e391c"] = " Youk De Goede ",
            ["1f6435ec793c74962deccd7533313404ef05e1557b1690776cfdadf7d3529295"] = " Thibault Joassard ",
            ["f9e81464564fe35394e38971344208ef36e4d6b125707d55ed5447de8f734531"] = " Maël San Jose ",
            ["75588575afd4d02d42cab9205c17d0d7453e028f9eec696f9b2c795f976bcb27"] = " Isabelle Forest ",
            ["6d1ba267355aa9dfa5e7390e9852b5ecfb1e56f6a623c14cef0ceb2eda727b03"] = " Guillaume Vermet ",
            ["ce74b6def606ecb85541f74ee941e40d04ec74885908b53cedf9828a32044552"] = " Arthur Michon ",
            ["dc08d30e76deccd8b31723e4383f901ba7b1c9e48014adc4930a2ed806e0918f"] = " Afaf Harrache ",
            ["4535a3d82579684fa43d1383a0ce5bd05c70a71e0b174e83a2713c2fbafd0874"] = " Fanny Accettola-Despres ",
            ["82935de131b7b02dde0befa5a6f1bcc379878845ffd708919c9cf97b55931235"] = " Philippe Adjadj ",
            ["9c7935962223c30f60189f5f13137f3f16c4a9492475cf657cc261f48793953e"] = " Ludovic Gibault ",
            ["5a1798b7f8b48229f273a5625cfcdfb4cb15dad69b27b56be86b995534b956df"] = " Robin Chatelus ",
            ["4e58a0d546dc5da641053afb403779b3d7e9f00ccab2353b836233525267f441"] = " Natalia Gracia ",
            ["1aa61e3f709096f842aa6c4990814955935f86b421ccef93871f2b8599fd5906"] = " Federic De Caro ",
            ["7e3168fc15ea511ad982a92de81ab4d618991a449a7a4e4db2131cf8456a6756"] = " Cédric Bossi ",
            ["6e41ceb74d7df65d0a5aafef74219c5efecbd228b0b543a671fa2687e344c789"] = " Roni Abdulnour ",
            ["708768f16f8c506df41d263ca933b15476c695aed6db8acd12a20450dcaa8d86"] = " Federica De Caro ",
            ["ae4059024944762285a3d443ad54006edfc7ab783751b9d88c98d562f0fb5e62"] = " Gwladys Mourouvin ",
            ["6a5e8e670769f473f5b50f489da603a75ea9e35c94fd61a93d07093b56f3b939"] = " Matthieu Chevalier ",
            ["496782926bdb4b2d45fa65b6e7fd12c0ca267e51ed856015915201d04f240090"] = " Jacques Donvez ",
            ["708768f16f8c506df41d263ca933b15476c695aed6db8acd12a20450dcaa8d86"] = " Alice Dupuits ",
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
