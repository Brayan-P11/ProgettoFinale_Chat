using Chat_Online.DTO;
using Chat_Online.Models;
using Chat_Online.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace Chat_Online.Services
{
    public class UtenteService
    {
        private readonly UtenteRepo _repository;

        public UtenteService(UtenteRepo repository)
        {
            _repository = repository;
        }

        public List<Utente> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<UtenteDto> RestituisciTutto()
        {
            List<UtenteDto> elenco = this.PrendiliTutti().Select(u => new UtenteDto()
            {
                Cod = u.Codice,
                Use = u.Username,
                Pas = u.PasswordU,
                IsDel = u.IsDeleted
            }).ToList();

            return elenco;
        }

        public bool EliminaPerCodice(UtenteDto uteDto)
        {
            Utente? temp = _repository.GetAll().FirstOrDefault(u => u.Codice == uteDto.Cod);

            if (temp is not null)
                return _repository.SoftDelete(temp.Codice);

            return false;
        }

        public static string CalculateMD5Hash(string input)
        {

            // Creazione dell'oggetto MD5
            using (MD5 md5 = MD5.Create())
            {

                // Conversione della stringa in un array di byte
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);

                // Calcolo dell'hash MD5
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Converting the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public bool CreaUtente(UtenteDto uteDto)
        {
            if (uteDto is not null)
            {
                try
                {
                    Utente temp = new Utente()
                    {
                        Username = uteDto.Use,
                        PasswordU = CalculateMD5Hash(uteDto.Pas)
                    };
                    return _repository.Insert(temp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return false;
        }


        //DA SISTEMARE
        // prende i valori Dto dal controller
        // ma non li riesce a passare alla repo
        // ma crea un nuovo utente
        public bool AggiornaUtente(UtenteDto uteDto)
        {
            if (uteDto is not null)
            {
                Utente temp = new Utente()
                {
                    Codice = uteDto.Cod,
                    Username = uteDto.Use,
                    PasswordU = uteDto.Pas,
                    IsDeleted = uteDto.IsDel
                };

                //_context.Utentes.FirstOrDefault(u => u.Username == uteDto.Use && u.PasswordU == uteDto.Pas);
                return _repository.Update(temp);
            }
            return false;
        }

        //---- LOGIN

        public bool LoginUtente(UtenteDto uteDto)
        {
            uteDto.Pas = CalculateMD5Hash(uteDto.Pas);

            return _repository.CheckLogin(uteDto) is not null ? true : false;
        }

        // da approfondire
        public UtenteDto PerEmail(string email) // perche la mail? se possiamo chiamarlo code?
        {
            Utente? temp = _repository.GetByCode(email);
            if (temp is not null)
            {
                UtenteDto prodto = new UtenteDto()
                    {
                        Cod = temp.Codice,
                        Use = temp.Username,
                        Pas = temp.PasswordU,
                        IsDel = temp.IsDeleted
                    };
                if (prodto is not null)
                {
                    return prodto;
                }
            }
            return new UtenteDto();
        }
    }
}
