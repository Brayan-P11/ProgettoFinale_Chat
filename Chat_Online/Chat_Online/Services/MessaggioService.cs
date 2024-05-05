using Chat_Online.DTO;
using Chat_Online.Models;
using Chat_Online.Repositories;

namespace Chat_Online.Services
{
    public class MessaggioService
    {
        private readonly MessaggioRepo _repository;

        public MessaggioService(MessaggioRepo repository)
        {
            _repository = repository;
        }

        public List<MessaggioDto> Restituisci()
        {
            List<MessaggioDto> elenco = new List<MessaggioDto>();
            foreach (Messaggio mess in _repository.GetAll())
            {
                elenco.Add(
                    new MessaggioDto ()
                    {
                        Codi = mess.Codice,
                        NomU = mess.NomeUtente,
                        Cont = mess.Contenuto,
                        Ora = mess.Orario
                    });
            }
            return elenco;
        }

        public bool Inserimento(MessaggioDto mesDto)
        {
            Messaggio mess = new Messaggio()
            {
                Codice = mesDto.Codi,
                NomeUtente = mesDto.NomU,
                Contenuto = mesDto.Cont,
                Orario = mesDto.Ora
            };

            return _repository.Insert(mess);
        }
    }
}
