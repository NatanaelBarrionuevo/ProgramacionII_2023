using TemperaturaWebApi.Models;

namespace TemperaturaWebApi.Datos
{
    public class TempSingletton
    {
        private static TempSingletton instance;
        private List<Temperatura> lst;
        private TempSingletton()
        {
            lst = new List<Temperatura>();
        }

        public static TempSingletton getInstance()
        {
            if (instance == null)
            {
                instance = new TempSingletton();
            }
            return instance;
        }

        public List<Temperatura> GetList()
        {
            return lst;
        }
        public List<Temperatura> InsertTemp(Temperatura oTemperatura)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == null)
                {
                    lst.Add(oTemperatura);
                }
            }
            return lst;
        }

        public List<Temperatura> GetTemp(int id, int iot)
        {
            List<Temperatura> aux = new List<Temperatura>();
            if(id == 0)
            {
                foreach(Temperatura t in lst)
                {
                    if(iot == t.Iot)
                    {
                        aux.Add(t);
                    }
                }
            }
            foreach (Temperatura t in lst)
            {
                if (t.Id == id)
                {
                    aux.Add(t);
                }
            }
            return aux;
        }
        
        public List<Temperatura> EjecutarTemp(int id)
        {
            Temperatura temperatura = new Temperatura();
            List<Temperatura> aux = new List<Temperatura>();
            if (id > 0)
            {
                foreach (Temperatura t in lst)
                {
                    if (t.Id == id)
                    {
                        temperatura = t;
                        lst.Remove(t);
                    }
                }
            }
            aux.Add(temperatura);
            return aux;
        }

        public List<Temperatura> EjecutarTemp(Temperatura oTemperatura)
        {
            List<Temperatura> aux = new List<Temperatura>();
            if (oTemperatura != null)
            {
                foreach (Temperatura t in lst)
                {
                    if (oTemperatura.Id == t.Id)
                    {
                        aux.Add(t);
                        aux.Add(oTemperatura);
                        t.Iot = oTemperatura.Iot;
                        t.FechaHora = oTemperatura.FechaHora;
                        t.Valor = oTemperatura.Valor;
                    }
                }
            }

            return aux;
        }
    }
}
