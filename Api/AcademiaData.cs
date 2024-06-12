using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api
{
    public interface IAcademiaData
    {
        Task <Data.Academia> AddAcademia(Data.Academia academia);
        Task <bool> DeleteAcademia(int id);
        Task<IEnumerable<Data.Academia>> GetAcademias();
        Task<Data.Academia> UpdateAcademia(Data.Academia academia);
    }
    public class AcademiaData :IAcademiaData
    {
        private readonly List<Data.Academia> academias = new List<Data.Academia>()
        {
            new Data.Academia
            {
                Id = 10,
                Name = "Tajamar",
                NameCFGS = "Desarrollo de aplicaciones Web, Administración de sistemas informáticos en red",
                Tipo = "DAW Online, ASIR Presencial",
                Description = "Centro Concertado de formacion especializado en Azure y AWS con masteres de especializacion",
                Distancia = "1,4",
                Turno = "ASIR de Mañana(?), DAW online sin horarios",
                Url = "https://fpprofessionaleducation.tajamar.es/tech/"
            },
            new Data.Academia 
            { 
                Id = 20,
                Name = "IES Clara del Rey",
                NameCFGS = "Desarrollo de aplicaciones Multiplataforma, DAW y ASIR",
                Tipo = "Dual, Doble titulacion DAM/DAW, Presencial, bilingüe",
                Description = "Centro público de formacion profesional",
                Distancia = "6,8",
                Turno = "Mañana/Tarde",
                Url = "https://iesclaradelrey.es/portal/index.php/es/"

            }
        };

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Data.Academia> AddAcademia(Data.Academia academia)
        {
            academia.Id = GetRandomInt();
            academias.Add(academia);
            return Task.FromResult(academia);
        }
        public Task<Data.Academia> UpdateAcademia(Data.Academia academia)
        {
            var index = academias.FindIndex(a => a.Id == academia.Id);
            academias[index] = academia; 
            return Task.FromResult(academia);
        }
        public Task<bool>DeleteAcademia(int id)
        {
            var index = academias.FindIndex(a => a.Id == id);
            academias.RemoveAt(index);
            return Task.FromResult(true);
        }
        public Task<IEnumerable<Data.Academia>> GetAcademias()
        {
            return Task.FromResult(academias.AsEnumerable());
        }
    }
 

}
