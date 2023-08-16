namespace Diseño
{
    class Utilidades
    {
        //variables:
        private bool Invitado;

        //Constructor:
        public Utilidades() 
        {
            Invitado = true;
        }

        //Getters y Setters:
        public bool getInvitado
        {
            get { return Invitado;}
        }
        public bool SetInvitado
        {
            set { Invitado = value; }
        }

        public string MostrarTest()
        {
            string consulta = "SELECT * FROM usuario";

            return consulta;
        }
    }
}
