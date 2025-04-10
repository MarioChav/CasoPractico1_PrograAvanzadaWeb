using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ParametroHelper : IParametroHelper
    {
        IServiceRepository _serviceRepository;

        public ParametroHelper(IServiceRepository serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        ParametroViewModel Convertir(ParametroAPI parametro)
        {
            return new ParametroViewModel
            {
                ParametroId = parametro.ParametroId,
                Descripcion = parametro.Descripcion
            };
        }

        ParametroAPI Convertir(ParametroViewModel parametro)
        {
            return new ParametroAPI
            {
                ParametroId = parametro.ParametroId,
                Descripcion = parametro.Descripcion
            };
        }

        public ParametroViewModel AddParametro(ParametroViewModel parametroViewModel)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/parametro", Convertir(parametroViewModel));
            if (response != null)
            {
                var content = response.Content;
            }
            return parametroViewModel;
        }

        public void DeleteParametro(int id)
        {
            HttpResponseMessage response = _serviceRepository.DeleteResponse("api/parametro/" + id.ToString());
            if (response != null)
            {
                var content = response.Content;
            }
        }

        public ParametroViewModel EditParametro(ParametroViewModel parametroViewModel)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("api/parametro", Convertir(parametroViewModel));
            if (response != null)
            {
                var content = response.Content;
            }
            return parametroViewModel;
        }

        public List<ParametroViewModel> GetAll()
        {
            List<ParametroAPI> parametros = new List<ParametroAPI>();
            HttpResponseMessage response = _serviceRepository.GetResponse("api/parametro");
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                parametros = JsonConvert.DeserializeObject<List<ParametroAPI>>(content);
            }
            List<ParametroViewModel> lista = new List<ParametroViewModel>();
            foreach (var item in parametros)
            {
                lista.Add(Convertir(item));
            }
            return lista;
        }

        public ParametroViewModel GetById(int id)
        {
            ParametroAPI parametro = new ParametroAPI();
            HttpResponseMessage response = _serviceRepository.GetResponse("api/parametro/" + id.ToString());
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                parametro = JsonConvert.DeserializeObject<ParametroAPI>(content);
            }
            return Convertir(parametro);
        }

    }
}
