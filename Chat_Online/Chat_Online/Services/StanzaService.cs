using Chat_Online.DTO;
using Chat_Online.Models;
using Chat_Online.Repositories;

namespace Chat_Online.Services
{
    public class StanzaService
    {
        private readonly StanzaRepo _repository;

        public StanzaService(StanzaRepo repository)
        {
            _repository = repository;
        }

        public List<StanzaDto> Restituisci()
        {
            List<StanzaDto> elenco = new List<StanzaDto>();
            foreach (Stanza stan in _repository.GetAll())
            {
                elenco.Add(
                    new StanzaDto()
                    {
                        CodS = stan.Codice,
                        Nome = stan.Nome,
                        Desc = stan.Descrzione,
                        MessaID = stan.MessaggioID,
                        Messa = ConvertiMessaggiInDTO(stan.Messaggios)

                    });
            }
            return elenco;
        }

        public bool Inserimento(StanzaDto stanDto)
        {
            Stanza stan = new Stanza()
            {
                Codice = stanDto.CodS,
                Nome = stanDto.Nome,
                Descrzione = stanDto.Desc,
                Messaggios = ConvertiMessaggi(stanDto.Messa)
            };

            return _repository.Insert(stan);
        }

        // Conversione 
        public List<MessaggioDto> ConvertiMessaggiInDTO(List<Messaggio>? messaggi)
        {
            List<MessaggioDto> elenco = new List<MessaggioDto>();
            if (messaggi is not null)
            {
                foreach (Messaggio mestemp in messaggi)
                {
                    elenco.Add(
                        new MessaggioDto()
                        {
                            Codi = mestemp.Codice,
                            NomU = mestemp.NomeUtente,
                            Cont = mestemp.Contenuto,
                            Ora = mestemp.Orario
                        });
                }
            }
            return elenco;
        }


        public List<Messaggio> ConvertiMessaggi(List<MessaggioDto>? messaggiDto)
        {
            List<Messaggio> elenco = new List<Messaggio>();
            if (messaggiDto is not null)
            {
                foreach (MessaggioDto mestemp in messaggiDto)
                {
                    elenco.Add(
                        new Messaggio()
                        {
                            Codice = mestemp.Codi,
                            NomeUtente = mestemp.NomU,
                            Contenuto = mestemp.Cont,
                            Orario = mestemp.Ora
                        });
                }
            }
            return elenco;
        }

    }
}
