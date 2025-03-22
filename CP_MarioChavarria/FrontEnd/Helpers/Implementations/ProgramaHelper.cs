using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{

    public class ProgramaHelper : IProgramaHelper
    {
        IServiceRepository _serviceRepository;

        public ProgramaHelper(IServiceRepository serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        ProgramaViewModel Convertir(ProgramaAPI programa) 
        {
            return new ProgramaViewModel 
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria

            };


            //ProgramaViewModel programaViewModel = new ProgramaViewModel
            //{
            //    ProgramaId = programa.ProgramaId,
            //    Nombre = programa.Nombre,
            //    Tipo = programa.Tipo,
            //    Categoria = programa.Categoria
            //};
            //return programaViewModel;
        }

        ProgramaAPI Convertir(ProgramaViewModel programa) 
        {
            return new ProgramaAPI
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
        }

        public ProgramaViewModel Add(ProgramaViewModel programa)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/programa", programa);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return programa;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProgramaViewModel> GetProgramas()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/programa");
            List<ProgramaAPI> programas = new List<ProgramaAPI>();
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                programas = JsonConvert.DeserializeObject<List<ProgramaAPI>>(content);
            }
            List<ProgramaViewModel> lista = new List<ProgramaViewModel>();
            foreach (var programa in programas)
            {
                lista.Add(Convertir(programa));
            }
            return lista;
        }

        public ProgramaViewModel GetPrograma(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/programa" + id.ToString());
            ProgramaAPI programa = new ProgramaAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                programa = JsonConvert.DeserializeObject<ProgramaAPI>(content);
            }
            ProgramaViewModel resultado = Convertir(programa);
            return resultado;
        }

        

        public ProgramaViewModel Update(ProgramaViewModel programa)
        {
            throw new NotImplementedException();
        }
    }
}
