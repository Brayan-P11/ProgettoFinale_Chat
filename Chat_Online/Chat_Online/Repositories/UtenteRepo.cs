using Chat_Online.DTO;
using Chat_Online.Models;

namespace Chat_Online.Repositories
{
    public class UtenteRepo : IRepo<Utente>
    {
        private readonly DbChatOnlineContext _context;

        public UtenteRepo (DbChatOnlineContext context)
        {
            _context = context;
        }

        public bool SoftDelete(string code)
        {
            try
            {

                Utente? temp = GetByCode(code);

                if (temp is not null)
                {
                    temp.IsDeleted = true;
                    _context.Utentes.Update(temp);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Utente> GetAll()
        {
            return _context.Utentes.ToList();
        }

        public Utente? GetByCode(string code)
        {
            return _context.Utentes.FirstOrDefault(u => u.Codice == code && u.IsDeleted == false);
        }

        public Utente? GetById(int id)
        {
            try
            {
                Utente? temp = _context.Utentes.Find(id);
                if (temp is not null && temp.IsDeleted == false)
                {
                    return temp;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);
                
            }
            return null;
        }

        public bool Insert(Utente item)
        {
            try
            {
                _context.Utentes.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }


        //DA IMPLEMENTARE MEGLIO DOMANI
        public bool Update(Utente item)
        {
            try
            {
                Utente? temp = item;
                _context.Utentes.Update(temp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }


        //------------------- Parte Login

        public Utente? CheckLogin(UtenteDto uteDto)
        {
            Utente? temp = _context.Utentes.FirstOrDefault(u => u.Username == uteDto.Use && u.PasswordU == uteDto.Pas);
            if (temp is not null)
            {
                return temp;
            }
            return temp;
        }


    }
}
