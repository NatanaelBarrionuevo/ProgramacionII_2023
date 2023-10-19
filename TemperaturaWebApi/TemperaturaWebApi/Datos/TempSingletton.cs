using TemperaturaWebApi.Models;

namespace TemperaturaWebApi.Datos
{
    public class TempSingletton
    {
        private static TempSingletton instance;
        private static readonly List<Temperatura> lst = new List<Temperatura>();
        private TempSingletton()
        {
            instance = null;
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
            lst.Add(oTemperatura);
            return lst;
        }

        public List<Temperatura> GetTemp(int cod)
        {
            List<Temperatura> aux = null;
            if (cod >= 0)
            {
                foreach (Temperatura t in lst)
                {
                    if (cod == t.CodIOT)
                    {
                        aux = new List<Temperatura>();
                        aux.Add(t);
                    }
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
                    if (t.CodIOT == id)
                    {
                        temperatura = t;
                        lst.Remove(t);
                    }
                }
            }
            aux.Add(temperatura);
            return aux;
        }

        public int ActualizarTemp(Temperatura oTemperatura)
        {
            int x = 0;
            if (oTemperatura != null)
            {
                foreach (Temperatura t in lst)
                {
                    if (oTemperatura.CodIOT == t.CodIOT)
                    {
                        t.CodIOT = oTemperatura.CodIOT;
                        t.FechaHora = oTemperatura.FechaHora;
                        t.Valor = oTemperatura.Valor;
                        x++;
                    }
                }
            }

            return x;
        }
        public int EliminarTemp(int cod)
        {
            int x = 0;
            if (cod > 0)
            {
                foreach (Temperatura t in lst)
                {
                    if (cod == t.CodIOT)
                    {
                        lst.Remove(t);
                        x++;
                    }
                }
            }
            return x;
        }

    }
}
