namespace ApiRestHeroesDeMalvinas.Response
{
    public class Respuesta
    {
        public int codigo { get; set; }
        public string mensaje { get; set; }

        public object Data { get; set; }

        public Respuesta() {
            codigo = 0;
            mensaje = "Respuesta default";
        }
    }
}
