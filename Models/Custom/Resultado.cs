namespace MyTalk.Models.Custom
{
    public class Resultado
    {
        public List<string> Columnas { get; set; }
        public string Registros { get; set; }
        public Resultado()
        {
            Columnas = new List<string>();
            Registros = "[]";
        }
    }
}
