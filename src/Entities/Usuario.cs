namespace src.Entities
{
    abstract class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Usuario))
            {
                return false;
            }

            Usuario outro = obj as Usuario;

            return Id.Equals(outro.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id
                + ", "
                + Nome;
        }
    }
}
